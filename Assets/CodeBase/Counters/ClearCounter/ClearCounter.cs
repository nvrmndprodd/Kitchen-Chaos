using CodeBase.KitchenObjects;

namespace CodeBase.Counters.ClearCounter
{
    public class ClearCounter : BaseCounter
    {
        public override void Interact(IKitchenObjectParent newParent)
        {
            if (!HasKitchenObject)
            {
                if (newParent.HasKitchenObject)
                {
                    newParent.KitchenObject.SetParent(this);
                }
                else
                {
                    
                }
            }
            else if (HasKitchenObject)
            {
                if (newParent.HasKitchenObject)
                {
                    TryToMoveIngredientToThePlate(newParent);
                }
                else
                {
                    KitchenObject.SetParent(newParent);
                }
            }
        }
    }
}