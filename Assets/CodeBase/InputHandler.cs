using UnityEngine;

namespace CodeBase
{
    public class InputHandler : MonoBehaviour
    {
        private PlayerInputActions _inputActions;

        private void Awake()
        {
            _inputActions = new PlayerInputActions();
            _inputActions.Player.Enable();
        }

        public Vector2 GetMovementVectorNormalized() => 
            _inputActions.Player.Move.ReadValue<Vector2>().normalized;
    }
}