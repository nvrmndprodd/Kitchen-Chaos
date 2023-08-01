using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase
{
    public class ClearCounter : MonoBehaviour
    {
        [SerializeField] private Transform counterTopContainer;
        [SerializeField] private KitchenObjectStaticData kitchenObjectData;

        private KitchenObject _kitchenObject;

        public void Interact()
        {
            if (_kitchenObject is not null) 
                return;
            
            _kitchenObject = Instantiate(kitchenObjectData.prefab, counterTopContainer);
            _kitchenObject.transform.localPosition = Vector3.zero;

            _kitchenObject.clearCounter = this;
        }
    }
}