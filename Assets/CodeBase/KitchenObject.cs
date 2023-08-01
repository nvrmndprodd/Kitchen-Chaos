using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase
{
    public class KitchenObject : MonoBehaviour
    {
        [SerializeField] private KitchenObjectStaticData kitchenObjectData;

        public ClearCounter clearCounter;

        public void SetCounter(ClearCounter counter)
        {
            if (clearCounter is not null)
                clearCounter.ClearKitchenObject();
            
            clearCounter = counter;
            clearCounter.SetKitchenObject(this);
            transform.parent = counter.CounterTopContainer;
            transform.localPosition = Vector3.zero;
        }
    }
}