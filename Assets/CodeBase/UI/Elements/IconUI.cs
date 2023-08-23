using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Elements
{
    public class IconUI : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private GameObject background;

        public void SetIcon(Sprite icon, bool enableBackground = true)
        {
            image.sprite = icon;
            background.SetActive(enableBackground);
        }
    }
}