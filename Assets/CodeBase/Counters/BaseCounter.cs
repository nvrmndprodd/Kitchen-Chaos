using CodeBase.KitchenObjects;
using UnityEngine;

namespace CodeBase.Counters
{
    public abstract class BaseCounter : MonoBehaviour, IKitchenObjectParent
    {
        [SerializeField] protected Transform counterTopContainer;
        
        public Transform KitchenObjectContainer => counterTopContainer;
        public KitchenObject KitchenObject { get; protected set; }
        public bool HasKitchenObject => KitchenObject is not null;
        
        public abstract void Interact(IKitchenObjectParent newParent);
        public virtual void InteractAlternate() {}
        
        public void SetKitchenObject(KitchenObject kitchenObject) => 
            KitchenObject = kitchenObject;

        public void ClearKitchenObject() => 
            KitchenObject = null;

        protected bool TryToMoveIngredientToThePlate(PlateKitchenObject plate)
        {
            if (!plate.TryAddIngredient(KitchenObject.Data)) 
                return false;
            
            KitchenObject.DestroySelf();
            return true;

        }
    }
}