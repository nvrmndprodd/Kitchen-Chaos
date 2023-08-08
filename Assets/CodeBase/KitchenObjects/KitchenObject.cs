using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.KitchenObjects
{
    public class KitchenObject : MonoBehaviour
    {
        [SerializeField] private KitchenObjectStaticData kitchenObjectData;

        private IKitchenObjectParent _parent;

        public KitchenObjectStaticData Data => kitchenObjectData;

        public void SetParent(IKitchenObjectParent parent)
        {
            if (_parent is not null)
                _parent.ClearKitchenObject();
            
            _parent = parent;
            _parent.SetKitchenObject(this);
            transform.parent = parent.KitchenObjectContainer;
            transform.localPosition = Vector3.zero;
        }

        public void DestroySelf()
        {
            _parent.ClearKitchenObject();
            Destroy(gameObject);
        }
    }
}