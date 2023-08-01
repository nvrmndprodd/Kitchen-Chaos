using CodeBase.Characters;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase
{
    public class ClearCounter : MonoBehaviour
    {
        [SerializeField] private Transform counterTopContainer;
        [SerializeField] private KitchenObjectStaticData kitchenObjectData;

        private KitchenObject _kitchenObject;

        public Transform CounterTopContainer => counterTopContainer;

        public void Interact(Player player)
        {
            if (_kitchenObject is null)
            {
                _kitchenObject = Instantiate(kitchenObjectData.prefab, counterTopContainer);
                _kitchenObject.SetCounter(this);
            }
        }

        public void SetKitchenObject(KitchenObject kitchenObject) => 
            _kitchenObject = kitchenObject;

        public KitchenObject GetKitchenObject()
            => _kitchenObject;

        public void ClearKitchenObject() =>
            _kitchenObject = null;

        public bool HasKitchenObject() => 
            _kitchenObject is not null;
    }
}