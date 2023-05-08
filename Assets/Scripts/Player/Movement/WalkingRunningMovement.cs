using System;
using ITB.Common;
using ITB.Interfaces;
using ITB.ScriptableObjects;
using UnityEngine;

namespace ITB.Player.Movement
{
    public class WalkingRunningMovement : IMovementBehaviour
    {
        public event Action<PlayerState> OnMovementStateChanged;
        public MovementType MovementType => MovementType.WalkingRunning;
        public bool IsDefault => data.isDefault;

        public float SpeedBoostFactor = 1f;
        public float JumpBoostFactor = 1f;

        private readonly WalkingRunningMovementData data;
        private readonly GameInput gameInput;

        private const float GroundCheckDistance = 0.2f;
        private const float GroundedOffset = 0.1f;

        private bool isGrounded;
        private float currentSpeed;
        private float targetSpeed;
        private float verticalVelocity;

        private float rotationY;
        private float rotationVelocity;
        private const float RotationSmoothTime = 0.2f;
        private const float Threshold = 0.01F;

        private float cinemachineTargetYaw;
        private float cinemachineTargetPitch;
        
        public WalkingRunningMovement(WalkingRunningMovementData data, GameInput gameInput)
        {
            this.data = data;
            this.gameInput = gameInput;
        }

        public (Vector3, Quaternion) UpdatePositionAndRotation(Vector3 position, Quaternion startRotation, Collider collider)
        {
            CheckForGrounded(position);
            position = HandleGravity(position);
            return Move(position, startRotation, collider);
        }

        public void OnEnable()
        {
            currentSpeed = data.moveSpeed;
            gameInput.OnJumpPreformed += Jump;
            gameInput.OnAccelerateStarted += GameInputOnAccelerateStarted;
            gameInput.OnAccelerateEnded += GameInputOnAccelerateEnded;
        }

        public void OnDisable()
        {
            gameInput.OnJumpPreformed -= Jump;
            gameInput.OnAccelerateStarted -= GameInputOnAccelerateStarted;
            gameInput.OnAccelerateEnded -= GameInputOnAccelerateEnded;
        }

        public void ApplyPowerUp(ScriptableObject powerUpData)
        {
            if (powerUpData.GetType() == typeof(SpeedJumpBoostPowerUpData))
            {
                var speedJumpBoostPowerUpData = (SpeedJumpBoostPowerUpData)powerUpData;
                SpeedBoostFactor = speedJumpBoostPowerUpData.speedBoostFactor;
                JumpBoostFactor = speedJumpBoostPowerUpData.jumpBoostFactor;
            }
        }

        private void Jump()
        {
            if (isGrounded)
            {
                verticalVelocity = Mathf.Sqrt(data.jumpHeight * -2f * data.gravity) * JumpBoostFactor;
                OnMovementStateChanged?.Invoke(PlayerState.Jumping);
            }
        }

        private Vector3 HandleGravity(Vector3 position)
        {
            var resultPosition = position;
            if (isGrounded)
            {
                if (verticalVelocity < 0.0f)
                {
                    verticalVelocity = 0f;
                    var spherePosition = new Vector3(position.x, position.y + GroundedOffset, position.z);
                    if (Physics.Raycast(spherePosition, Vector3.down, out var hit, GroundCheckDistance,
                            data.groundLayers))
                    {
                        if (hit.distance > GroundedOffset)
                        {
                            resultPosition = hit.point;
                        }
                    }
                    OnMovementStateChanged?.Invoke(PlayerState.Walking);
                }
            }
            else
            {
                verticalVelocity += data.gravity * Time.deltaTime;
            }

            return resultPosition;
        }

        private void CheckForGrounded(Vector3 position)
        {
            var spherePosition = new Vector3(position.x, position.y + GroundedOffset, position.z);
            isGrounded = Physics.CheckSphere(spherePosition, GroundCheckDistance, data.groundLayers);
        }

        private (Vector3, Quaternion) Move(Vector3 position, Quaternion startRotation, Collider collider)
        {
            var inputVector = gameInput.GetMovementVectorNormalized();
            var moveDir = new Vector3(inputVector.x, 0, inputVector.y);

            Accelerate(moveDir);
            var rotation = RotatePlayer(moveDir, startRotation);

            var targetDirection = Quaternion.Euler(0.0f, rotationY, 0.0f) * Vector3.forward;
            var moveDistance = currentSpeed * SpeedBoostFactor * Time.deltaTime;
            var horizontalMovement = targetDirection.normalized * moveDistance;
            var verticalMovement = new Vector3(0.0f, verticalVelocity, 0.0f) * Time.deltaTime;
            var movement = horizontalMovement + verticalMovement;

            // Stair detection and adjustment
            if (isGrounded)
            {
                if (Physics.Raycast(position + movement + Vector3.up * data.stairStepHeight, Vector3.down, out var hit, data.stairStepHeight, data.groundLayers))
                {
                    var stairHeight = hit.point.y - position.y;
                    if (stairHeight <= data.stairStepHeight && stairHeight > 0)
                    {
                        position.y = hit.point.y;
                    }
                }
            }
            
            var raycastHits = new RaycastHit[5];
            Vector3 startPoint = position + Vector3.up * (GroundedOffset + data.playerRadius);
            Vector3 endPoint = position + Vector3.up * (data.playerHeight - data.playerRadius);
            
            //TODO:Refactor this

            var hitsNumber = Physics.CapsuleCastNonAlloc(startPoint, endPoint, data.playerRadius,
                targetDirection.normalized, raycastHits, moveDistance, data.groundLayers);
            var resultMovementDiff = movement;
            
            if (hitsNumber == 0)
            {
                resultMovementDiff = movement;
            }
            else
            {
                var averageHitNormal = Vector3.zero;
                for (var i = 0; i < hitsNumber; i++)
                {
                    averageHitNormal += raycastHits[i].normal;
                }

                averageHitNormal /= hitsNumber;

                var slideMovement = Vector3.ProjectOnPlane(movement, averageHitNormal);
                if (Vector3.Angle(movement, slideMovement) < 160)
                {
                    resultMovementDiff = slideMovement;
                }
            }
            
            var edgeHitsNumber = Physics.CapsuleCastNonAlloc(startPoint, endPoint, data.playerRadius,
                targetDirection.normalized, raycastHits, moveDistance, data.edgeLayers);
            
            if (edgeHitsNumber == 0)
            {
                position += resultMovementDiff;
            }
            else
            {
                if (!isGrounded)
                {
                    position += resultMovementDiff;
                }
                else
                {
                    var averageHitNormal = Vector3.zero;
                    for (var i = 0; i < edgeHitsNumber; i++)
                    {
                        averageHitNormal += raycastHits[i].normal;
                    }

                    averageHitNormal /= edgeHitsNumber;

                    var slideMovement = Vector3.ProjectOnPlane(movement, averageHitNormal);
                    if (Vector3.Angle(movement, slideMovement) < 160)
                    {
                        position += slideMovement;
                    }
                }
            }

            ResolveCollision(ref position, collider);

            return (position, rotation);
        }

        private void Accelerate(Vector3 moveDir)
        {
            if (moveDir == Vector3.zero)
            {
                targetSpeed = 0f;
            }
            else
            {
                targetSpeed = gameInput.IsAccelerateActive() ? data.maxSpeed : data.moveSpeed;
            }

            const float offset = 0.01f;
            if (currentSpeed < data.maxSpeed - offset || currentSpeed > targetSpeed + offset)
            {
                currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed * moveDir.magnitude,
                    data.accelerationFactor * Time.deltaTime);
            }
            else
            {
                currentSpeed = targetSpeed;
            }
        }

        private Quaternion RotatePlayer(Vector3 moveDir, Quaternion startRotation)
        {
            if (moveDir == Vector3.zero) return startRotation;

            rotationY = Mathf.Atan2(moveDir.x, moveDir.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            var rotation = Mathf.SmoothDampAngle(startRotation.eulerAngles.y, rotationY, ref rotationVelocity,
                RotationSmoothTime);
            return Quaternion.Euler(0f, rotation, 0f);
        }

        public Quaternion RotateCamera()
        {
            var lookInput = gameInput.GetLookInput();
            if (lookInput.sqrMagnitude >= Threshold)
            {
                cinemachineTargetYaw += lookInput.x * data.mouseSensitivity * Time.deltaTime;
                var invertYmodifier = data.invertY ? -1 : 1;
                cinemachineTargetPitch += lookInput.y * data.mouseSensitivity * invertYmodifier * Time.deltaTime;
            }

            cinemachineTargetYaw = ClampAngle(cinemachineTargetYaw, float.MinValue, float.MaxValue);
            cinemachineTargetPitch = ClampAngle(cinemachineTargetPitch, -data.cameraDownVerticalLimit,
                data.cameraUpVerticalLimit);
            return Quaternion.Euler(cinemachineTargetPitch, cinemachineTargetYaw, 0.0f);
        }

        private static float ClampAngle(float angle, float minAngle, float maxAngle)
        {
            if (angle < -360f)
            {
                angle += 360f;
            }

            if (angle > 360f)
            {
                angle -= 360f;
            }

            return Mathf.Clamp(angle, minAngle, maxAngle);
        }
        
        private void GameInputOnAccelerateStarted()
        {
            OnMovementStateChanged?.Invoke(PlayerState.Running);
        }
        
        private void GameInputOnAccelerateEnded()
        {
            OnMovementStateChanged?.Invoke(PlayerState.Walking);
        }
        
        private void ResolveCollision(ref Vector3 position, Collider playerCollider)
        {
            var colliders = Physics.OverlapCapsule(position + Vector3.up * (GroundedOffset + data.playerRadius),
                position + Vector3.up * (data.playerHeight - data.playerRadius),
                data.playerRadius,
                data.groundLayers);

            foreach (var collider in colliders)
            {
                if (Physics.ComputePenetration(playerCollider,
                        position,
                        Quaternion.identity,
                        collider,
                        collider.transform.position,
                        collider.transform.rotation,
                        out var direction,
                        out var distance))
                {
                    position += direction * distance;
                }
            }
        }
    }
}