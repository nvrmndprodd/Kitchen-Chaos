using CodeBase.Characters;
using UnityEngine;

namespace CodeBase
{
    public abstract class BaseCounter : MonoBehaviour, IKitchenObjectParent
    {
        [SerializeField] protected Transform counterTopContainer;
        
        public Transform KitchenObjectContainer => counterTopContainer;
        public KitchenObject KitchenObject { get; protected set; }
        public bool HasKitchenObject => KitchenObject is not null;
        
        public abstract void Interact(IKitchenObjectParent newParent);
        public virtual void InteractAlternate(Player player) {}
        
        public void SetKitchenObject(KitchenObject kitchenObject) => 
            KitchenObject = kitchenObject;

        public void ClearKitchenObject() => 
            KitchenObject = null;
    }
}