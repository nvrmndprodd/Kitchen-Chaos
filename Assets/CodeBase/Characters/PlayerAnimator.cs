using UnityEngine;

namespace CodeBase.Characters
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        public void StartMoving() => 
            animator.SetBool(Parameters.IS_WALKING, true);

        public void StopMoving() => 
            animator.SetBool(Parameters.IS_WALKING, false);
    }
}