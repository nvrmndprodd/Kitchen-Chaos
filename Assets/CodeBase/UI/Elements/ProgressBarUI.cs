using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Elements
{
    public class ProgressBarUI : MonoBehaviour
    {
        [SerializeField] private Image barImage;

        private void OnDisable() => 
            barImage.fillAmount = 0f;

        public void SetProgress(float progress) => 
            barImage.fillAmount = progress;
    }
}