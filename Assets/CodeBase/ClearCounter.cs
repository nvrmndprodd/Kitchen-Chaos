using CodeBase.Characters;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase
{
    public class ClearCounter : MonoBehaviour, IKitchenObjectParent
    {
        [SerializeField] private Transform counterTopContainer;
        [SerializeField] private KitchenObjectStaticData kitchenObjectData;

        public KitchenObject KitchenObject { get; private set; }
        
        public Transform KitchenObjectContainer => counterTopContainer;
        public bool HasKitchenObject => KitchenObject is not null;


        public void Interact(Player player)
        {
            if (KitchenObject is null)
            {
                KitchenObject = Instantiate(kitchenObjectData.prefab, counterTopContainer);
                KitchenObject.SetParent(this);
            }
            else
            {
                KitchenObject.SetParent(player);
            }
        }

        public void SetKitchenObject(KitchenObject kitchenObject) => 
            KitchenObject = kitchenObject;


        public void ClearKitchenObject() =>
            KitchenObject = null;
    }
}