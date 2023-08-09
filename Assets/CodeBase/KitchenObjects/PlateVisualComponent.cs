using CodeBase.StaticData;
using CodeBase.UI.Elements;
using UnityEngine;

namespace CodeBase.KitchenObjects
{
    public class PlateVisualComponent : MonoBehaviour
    {
        [SerializeField] private PlateCompleteVisual completeVisual;
        [SerializeField] private PlateIconsUI iconsUI;
        
        public void OnIngredientAdded(KitchenObjectStaticData data)
        {
            completeVisual.OnIngredientAdded(data);
            iconsUI.OnIngredientAdded(data);
        }
    }
}