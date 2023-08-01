using CodeBase.Characters;

namespace CodeBase
{
    public class ClearCounter : BaseCounter
    {
        public override void Interact(IKitchenObjectParent newParent)
        {
            if (!HasKitchenObject && newParent.HasKitchenObject)
            {
                if (newParent.HasKitchenObject) 
                    newParent.KitchenObject.SetParent(this);
            }
            else if (!newParent.HasKitchenObject)
                KitchenObject.SetParent(newParent);
        }
    }
}