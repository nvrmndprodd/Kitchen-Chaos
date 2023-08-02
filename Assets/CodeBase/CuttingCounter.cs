using CodeBase.Characters;

namespace CodeBase
{
    public class CuttingCounter : BaseCounter
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

        public override void InteractAlternate(Player player)
        {
            if (!HasKitchenObject || !KitchenObject.CanBeSliced) return;

            var previousKitchenObject = KitchenObject;
            GameFactory.CreateKitchenObject(KitchenObject.SlicedObject, this);
            previousKitchenObject.DestroySelf();
        }
    }
}