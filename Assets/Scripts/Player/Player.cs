using System;
using System.Collections.Generic;
using System.Linq;
using ITB.Interfaces;
using ITB.Player.Movement;
using UnityEngine;
using Zenject;

namespace ITB.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Transform cameraLookTransform;
        [SerializeField] private PlayerShooting playerShooting;

        public event Action<PlayerState> OnPlayerStateChanged;
        public Transform CameraLookTransform => cameraLookTransform;
        
        private Dictionary<MovementType, IMovementBehaviour> movementBehaviorLookup;
        private IMovementBehaviour activeMovementBehavior;
        private Collider collider;
        
        [Inject]
        public void Construct(Dictionary<MovementType, IMovementBehaviour> movementBehaviorLookup)
        {
            this.movementBehaviorLookup = movementBehaviorLookup;
            this.collider = GetComponent<Collider>();
        }
        
        private void Start()
        {
            var defaultBehaviourType = MovementType.WalkingRunning;
            var (movementType, behaviour) = movementBehaviorLookup.FirstOrDefault(x => x.Value.IsDefault);
            if (behaviour != default)
            {
                defaultBehaviourType = movementType;
            }
            SetActiveMovementBehavior(defaultBehaviourType);
        }

        private void Update()
        {
            if (activeMovementBehavior != null)
            {
                var result = activeMovementBehavior.UpdatePositionAndRotation(transform.position, transform.rotation, collider);
                transform.position = result.position;
                transform.rotation = result.rotation;
            }
        }

        private void LateUpdate()
        {
            if (activeMovementBehavior != null)
            {
                CameraLookTransform.rotation = activeMovementBehavior.RotateCamera();
            }
        }

        public void SetActiveMovementBehavior(MovementType type)
        {
            if (movementBehaviorLookup.TryGetValue(type, out var behavior))
            {
                if (activeMovementBehavior != null)
                {
                    activeMovementBehavior.OnDisable();
                    activeMovementBehavior.OnMovementStateChanged -= HandleMovementStateChanged;
                }

                activeMovementBehavior = behavior;
                
                activeMovementBehavior.OnEnable();
                activeMovementBehavior.OnMovementStateChanged += HandleMovementStateChanged;
            }
            else
            {
                Debug.LogError($"Movement behavior not found for type: {type}");
            }
        }

        public void ApplySpeedJumpBoostPowerUp(float speedFactor, float jumpFactor)
        {
            if (activeMovementBehavior.GetType() == typeof(WalkingRunningMovement))
            {
                var movement = (WalkingRunningMovement)activeMovementBehavior;
                movement.SpeedBoostFactor *= speedFactor;
                movement.JumpBoostFactor *= jumpFactor;
            }
        }

        public void ApplyDamageMultiplier(float damageMultiplier) =>
            playerShooting.ApplyDamageMultiplier(damageMultiplier);
        
        private void HandleMovementStateChanged(PlayerState state)
        {
            OnPlayerStateChanged?.Invoke(state);
        }
    }
}