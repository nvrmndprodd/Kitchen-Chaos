using CodeBase.KitchenObjects;
using UnityEngine;

namespace CodeBase.Counters.DeliveryCounter
{
    public class DeliveryCounter : BaseCounter
    {
        [SerializeField] private RecipeService recipeService;
        public override void Interact(IKitchenObjectParent newParent)
        {
            if (newParent.HasKitchenObject)
            {
                if (newParent.KitchenObject is PlateKitchenObject plate)
                {
                    plate.DestroySelf();
                    recipeService.DeliverRecipe(plate);
                }
            }
        }
    }
}