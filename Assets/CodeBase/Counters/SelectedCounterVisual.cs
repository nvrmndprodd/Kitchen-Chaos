using UnityEngine;

namespace CodeBase.Counters
{
    public class SelectedCounterVisual : MonoBehaviour
    {
        [SerializeField] private BaseCounter counter;
        [SerializeField] private GameObject[] visualGOs;
        
        private void Start() =>
            Player.Player.Instance.OnSelectedCounterChanged += OnSelectedCounterChanged;

        private void OnSelectedCounterChanged(object sender, Player.Player.OnSelectedCounterChangedEventArgs e)
        {
            if (e.selectedCounter == counter)
                Show();
            else
                Hide();
        }

        private void Show()
        {
            foreach(var visualGO in visualGOs)
                visualGO.SetActive(true);
        }

        private void Hide()
        {
            foreach(var visualGO in visualGOs) 
                visualGO.SetActive(false);
        }
    }
}