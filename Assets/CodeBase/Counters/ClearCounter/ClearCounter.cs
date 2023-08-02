using CodeBase.KitchenObject;

namespace CodeBase.Counters.ClearCounter
{
    public class ClearCounter : BaseCounter
    {
        public override void Interact(IKitchenObjectParent newParent)
        {
            if (!HasKitchenObject && newParent.HasKitchenObject)
                newParent.KitchenObject.SetParent(this);
            else if (HasKitchenObject && !newParent.HasKitchenObject)
                KitchenObject.SetParent(newParent);
        }
    }
}