using UnityEngine;

namespace CodeBase.KitchenObjects
{
    public interface IKitchenObjectParent
    {
        Transform KitchenObjectContainer { get; }
        KitchenObject KitchenObject { get; }
        bool HasKitchenObject { get; }

        void SetKitchenObject(KitchenObject kitchenObject);
        void ClearKitchenObject();
    }
}