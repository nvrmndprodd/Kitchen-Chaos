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
            var acceleration = Time.deltaTime * data.speed;
            var canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * data.playerHeight, data.playerRadius, direction, acceleration);

            if (IsNotMoving(direction))
            {
                animator.StopMoving();
                return;
            }
            
            if (!canMove)
            {
                var directionX = new Vector3(direction.x, 0, 0).normalized;
                var canMoveX = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * data.playerHeight, data.playerRadius, directionX, acceleration);

                if (canMoveX)
                    direction = directionX;
                else
                {
                    var directionZ = new Vector3(0, 0, direction.z).normalized;
                    var canMoveZ = !Physics.CapsuleCast(transform.position,
                        transform.position + Vector3.up * data.playerHeight, data.playerRadius, directionZ,
                        acceleration);

                    if (canMoveZ)
                        direction = directionZ;
                    else
                        return;
                }

            }

            transform.position += direction * acceleration;
            transform.forward = Vector3.Slerp(transform.forward, direction, Time.deltaTime * data.rotationSpeed);
            animator.StartMoving();
        }

        private static bool IsNotMoving(Vector3 input) => 
            input.sqrMagnitude <= float.Epsilon;
    }
}