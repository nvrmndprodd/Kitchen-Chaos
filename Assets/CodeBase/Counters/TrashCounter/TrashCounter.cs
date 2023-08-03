using CodeBase.KitchenObject;

namespace CodeBase.Counters.TrashCounter
{
    public class TrashCounter : BaseCounter
    {
        public override void Interact(IKitchenObjectParent newParent)
        {
            if (newParent.HasKitchenObject) 
                newParent.KitchenObject.DestroySelf();
        }
    }
}