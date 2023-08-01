using CodeBase.Characters;
using UnityEngine;
using UnityEngine.Serialization;

namespace CodeBase
{
    public class SelectedCounterVisual : MonoBehaviour
    {
        [SerializeField] private ClearCounter clearCounter;
        [SerializeField] private GameObject visualGO;
        
        private void Start()
        {
            Player.Instance.OnSelectedCounterChanged += OnSelectedCounterChanged;
        }

        private void OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e)
        {
            if (e.selectedCounter == clearCounter)
                Show();
            else
                Hide();
        }

        private void Show()
        {
            visualGO.SetActive(true);
        }

        private void Hide()
        {
            visualGO.SetActive(false);
        }
    }
}