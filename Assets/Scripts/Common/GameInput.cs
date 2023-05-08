using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ITB.Common
{
    public class GameInput
    {
        public event Action OnJumpPreformed;
        public event Action OnAccelerateStarted;
        public event Action OnAccelerateEnded;
        public event Action OnPrimaryShoot;
        public event Action OnSecondaryShoot;

        private readonly PlayerInputActions playerInputActions;
        private GameInput()
        {
            playerInputActions = new PlayerInputActions();
            EnableInput();
        }
        
        public Vector2 GetMovementVectorNormalized() => playerInputActions.Player.Move.ReadValue<Vector2>().normalized;

        public bool IsAccelerateActive() => playerInputActions.Player.Accelerate.IsPressed();

        public Vector2 GetLookInput() => playerInputActions.Player.Look.ReadValue<Vector2>();

        private void EnableInput()
        {
            playerInputActions.Player.Enable();
            playerInputActions.Player.Jump.performed += HandleJumpPerformed;
            playerInputActions.Player.Accelerate.started += HandleAccelerateStarted;
            playerInputActions.Player.Accelerate.canceled += HandleAccelerateEnded;
            playerInputActions.Player.PrimaryShoot.performed += HandlePrimaryShootPerformed;
            playerInputActions.Player.SecondaryShoot.performed += HandleSecondaryShootPerformed;
        }

        private void DisableInput()
        {
            playerInputActions.Player.Jump.performed -= HandleJumpPerformed;
            playerInputActions.Player.Accelerate.started -= HandleAccelerateStarted;
            playerInputActions.Player.Accelerate.canceled -= HandleAccelerateEnded;
            playerInputActions.Player.PrimaryShoot.performed -= HandlePrimaryShootPerformed;
            playerInputActions.Player.SecondaryShoot.performed -= HandleSecondaryShootPerformed;
            playerInputActions.Player.Disable();
        }

        private void HandleAccelerateStarted(InputAction.CallbackContext obj)
        {
            OnAccelerateStarted?.Invoke();
        }
        
        private void HandleAccelerateEnded(InputAction.CallbackContext obj)
        {
            OnAccelerateEnded?.Invoke();
        }

        private void HandleJumpPerformed(InputAction.CallbackContext obj)
        {
            OnJumpPreformed?.Invoke();
        }
        
        private void HandlePrimaryShootPerformed(InputAction.CallbackContext obj)
        {
            OnPrimaryShoot?.Invoke();
        }
        private void HandleSecondaryShootPerformed(InputAction.CallbackContext obj)
        {
            OnSecondaryShoot?.Invoke();
        }
    }
}