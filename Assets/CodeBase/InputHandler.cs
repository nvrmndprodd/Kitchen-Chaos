using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CodeBase
{
    public class InputHandler : MonoBehaviour
    {
        public event EventHandler OnInteractAction;
        public event EventHandler OnInteractAlternateAction;
        
        private PlayerInputActions _inputActions;

        private void Awake()
        {
            _inputActions = new PlayerInputActions();
            _inputActions.Player.Enable();

            _inputActions.Player.Interact.performed += InteractPerformed;
            _inputActions.Player.InteractAlternate.performed += InteractAlternatePerformed;
        }

        public Vector2 GetMovementVectorNormalized() => 
            _inputActions.Player.Move.ReadValue<Vector2>().normalized;

        private void InteractPerformed(InputAction.CallbackContext context) => 
            OnInteractAction?.Invoke(this, EventArgs.Empty);

        private void InteractAlternatePerformed(InputAction.CallbackContext obj) => 
            OnInteractAlternateAction?.Invoke(this, EventArgs.Empty);
    }
}