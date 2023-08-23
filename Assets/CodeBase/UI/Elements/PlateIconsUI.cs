using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.UI.Elements
{
    public class PlateIconsUI : MonoBehaviour
    {
        [SerializeField] private IconUI singleIconPrefab;

        public void OnIngredientAdded(KitchenObjectStaticData data)
        {
            var icon = Instantiate(singleIconPrefab, transform);
            icon.SetIcon(data.icon);
        }

        public void Reset()
        {
            for (var i = 0; i < transform.childCount; i++) 
                Destroy(transform.GetChild(i).gameObject);
        }
    }
}