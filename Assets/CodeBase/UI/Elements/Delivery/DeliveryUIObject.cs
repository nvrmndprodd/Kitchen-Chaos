using CodeBase.StaticData;
using TMPro;
using UnityEngine;

namespace CodeBase.UI.Elements.Delivery
{
    public class DeliveryUIObject : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI label;
        [SerializeField] private Transform iconContainer;
        [SerializeField] private IconUI prefab;

        public void Construct(RecipeStaticData recipeData)
        {
            label.text = recipeData.recipeTitle;

            foreach (Transform child in iconContainer) 
                Destroy(child.gameObject);

            foreach (var ingredient in recipeData.kitchenObjects)
                Instantiate(prefab, iconContainer).SetIcon(ingredient.icon, false);
        }
    }
}