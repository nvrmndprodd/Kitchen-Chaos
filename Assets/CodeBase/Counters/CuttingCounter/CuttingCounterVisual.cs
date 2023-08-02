using CodeBase.UI.Elements;
using UnityEngine;

namespace CodeBase.Counters.CuttingCounter
{
    public class CuttingCounterVisual : MonoBehaviour
    {
        [SerializeField] private ProgressBarUI progressBar;
        [SerializeField] private Animator animator;

        public void EnableProgressBar() => 
            progressBar.gameObject.SetActive(true);

        public void DisableProgressBar() => 
            progressBar.gameObject.SetActive(false);

        public void UpdateProgress(float value, float maxValue) => 
            progressBar.SetProgress(value / maxValue);

        public void StartCuttingAnimation() => 
            animator.SetTrigger(Parameters.CUT);
    }
}