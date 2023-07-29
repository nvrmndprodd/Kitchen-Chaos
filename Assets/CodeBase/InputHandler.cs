using UnityEngine;

namespace CodeBase
{
    public class InputHandler : MonoBehaviour
    {
        public Vector2 GetMovementVectorNormalized()
        {
            var inputVector = Vector3.zero;

            inputVector.x = Input.GetAxis("Horizontal");
            inputVector.y = Input.GetAxis("Vertical");

            return inputVector.normalized;
        }
    }
}