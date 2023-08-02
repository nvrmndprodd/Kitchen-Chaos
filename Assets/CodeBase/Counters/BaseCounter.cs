using CodeBase.KitchenObject;
using UnityEngine;

namespace CodeBase.Counters
{
    public abstract class BaseCounter : MonoBehaviour, IKitchenObjectParent
    {
        [SerializeField] protected Transform counterTopContainer;
        
        public Transform KitchenObjectContainer => counterTopContainer;
        public KitchenObject.KitchenObject KitchenObject { get; protected set; }
        public bool HasKitchenObject => KitchenObject is not null;
        
        public abstract void Interact(IKitchenObjectParent newParent);
        public virtual void InteractAlternate(Player.Player player) {}
        
        public void SetKitchenObject(KitchenObject.KitchenObject kitchenObject) => 
            KitchenObject = kitchenObject;

        public void ClearKitchenObject() => 
            KitchenObject = null;
    }
}