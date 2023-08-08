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
            else
            {
                if (newParent.HasKitchenObject)
                {
                    if (newParent.KitchenObject is PlateKitchenObject plate)
                    {
                        if (plate.TryAddIngredient(KitchenObject.Data))
                            KitchenObject.DestroySelf();
                    }
                    
                    if (KitchenObject is PlateKitchenObject p)
                    {
                        if (p.TryAddIngredient(newParent.KitchenObject.Data))
                            newParent.KitchenObject.DestroySelf();
                    }
                }
                else
                {
                    KitchenObject.SetParent(newParent);
                }
            }
        }
    }
}