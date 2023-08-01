using CodeBase.Characters;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase
{
    public abstract class BaseCounter : MonoBehaviour, IKitchenObjectParent
    {
        [SerializeField] protected Transform counterTopContainer;
        [SerializeField] protected KitchenObjectStaticData kitchenObjectData;
        
        public Transform KitchenObjectContainer => counterTopContainer;
        public KitchenObject KitchenObject { get; protected set; }
        public bool HasKitchenObject => KitchenObject is not null;
        
        public abstract void Interact(Player player);

        public void SetKitchenObject(KitchenObject kitchenObject) => 
            KitchenObject = kitchenObject;

        public void ClearKitchenObject() => 
            KitchenObject = null;
    }
}