using CodeBase.Characters;

namespace CodeBase
{
    public class CuttingCounter : BaseCounter
    {
        public override void Interact(IKitchenObjectParent newParent)
        {
            if (!HasKitchenObject && newParent.HasKitchenObject)
            {
                if (newParent.KitchenObject.CanBeSliced) 
                    newParent.KitchenObject.SetParent(this);
            }
            else if (!newParent.HasKitchenObject)
                KitchenObject.SetParent(newParent);
        }

        public override void InteractAlternate(Player player)
        {
            if (!HasKitchenObject || !KitchenObject.CanBeSliced) return;

            var slicedObject = KitchenObject.SlicedObject;
            KitchenObject.DestroySelf();
            GameFactory.CreateKitchenObject(slicedObject, this);
        }
    }
}