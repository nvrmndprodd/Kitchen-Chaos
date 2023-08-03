using CodeBase.UI.Elements;
using UnityEngine;

namespace CodeBase.Counters.StoveCounter
{
    public class StoveCounterVisual : MonoBehaviour
    {
        [SerializeField] private GameObject stoveGlow;
        [SerializeField] private GameObject particles;
        [SerializeField] private ProgressBarUI progressBar;

        public void Toggle(bool state)
        {
            stoveGlow.SetActive(state);
            particles.SetActive(state);
            progressBar.gameObject.SetActive(state);
        }

        public void UpdateProgress(float value, float maxValue) => 
            progressBar.SetProgress(value / maxValue);
    }
}