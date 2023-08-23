using UnityEngine;

namespace CodeBase.UI.Elements.Delivery
{
    public class DeliveryUI : MonoBehaviour
    {
        [SerializeField] private Transform container;
        [SerializeField] private DeliveryUIObject prefab;
        [SerializeField] private RecipeService recipeService;

        private void Start()
        {
            recipeService.RecipeAdded += UpdateVisual;
            UpdateVisual();
        }

        private void UpdateVisual()
        {
            foreach (Transform child in container) 
                Destroy(child.gameObject);

            foreach (var pendingRecipe in recipeService.PendingRecipes)
            {
                Instantiate(prefab, container).Construct(pendingRecipe);
            }
        }
    }
}