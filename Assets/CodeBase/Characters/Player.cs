using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Characters
{
    public class Player : MonoBehaviour
    {
        public PlayerStaticData data;
        public PlayerAnimator animator;
        
        private void Update()
        {
            var inputVector = Vector3.zero;

            inputVector.x = Input.GetAxis("Horizontal");
            inputVector.y = Input.GetAxis("Vertical");

            if (IsNotMoving(inputVector))
            {
                animator.StopMoving();
                return;
            }

            inputVector.Normalize();
            var direction = new Vector3(inputVector.x, 0f, inputVector.y);

            transform.position += (direction * (Time.deltaTime * data.speed));
            transform.forward = Vector3.Slerp(transform.forward, direction, Time.deltaTime * data.rotationSpeed);
            
            animator.StartMoving();
        }

        private static bool IsNotMoving(Vector3 input) => 
            input.sqrMagnitude <= float.Epsilon;
    }
}