using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CodeBase
{
    public class InputHandler : MonoBehaviour
    {
        public event EventHandler OnInteractAction;
        
        private PlayerInputActions _inputActions;

        private void Awake()
        {
            _inputActions = new PlayerInputActions();
            _inputActions.Player.Enable();

            _inputActions.Player.Interact.performed += InteractPerformed;
        }

        public Vector2 GetMovementVectorNormalized() => 
            _inputActions.Player.Move.ReadValue<Vector2>().normalized;

        private void InteractPerformed(InputAction.CallbackContext context) => 
            OnInteractAction?.Invoke(this, EventArgs.Empty);
    }
}