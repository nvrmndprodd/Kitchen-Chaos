using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Elements
{
    public class PlateSingleIconUI : MonoBehaviour
    {
        [SerializeField] private Image image;

        public void SetIcon(Sprite icon)
        {
            image.sprite = icon;
        }
    }
}