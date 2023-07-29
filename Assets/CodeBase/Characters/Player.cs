using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Characters
{
    public class Player : MonoBehaviour
    {
        public PlayerStaticData data;
        public PlayerAnimator animator;
        public InputHandler inputHandler;
        
        private void Update()
        {
            var inputVector = inputHandler.GetMovementVectorNormalized();
            var direction = new Vector3(inputVector.x, 0f, inputVector.y);

            if (IsNotMoving(direction))
            {
                animator.StopMoving();
                return;
            }

            transform.position += (direction * (Time.deltaTime * data.speed));
            transform.forward = Vector3.Slerp(transform.forward, direction, Time.deltaTime * data.rotationSpeed);
            
            animator.StartMoving();
        }

        private static bool IsNotMoving(Vector3 input) => 
            input.sqrMagnitude <= float.Epsilon;
    }
}