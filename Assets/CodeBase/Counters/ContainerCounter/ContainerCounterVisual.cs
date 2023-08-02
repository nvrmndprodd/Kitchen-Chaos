using UnityEngine;

namespace CodeBase.Counters.ContainerCounter
{
    public class ContainerCounterVisual : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        public void StartOpenCloseAnimation()
        {
            animator.SetTrigger(Parameters.OPEN_CLOSE);
        }
    }
}