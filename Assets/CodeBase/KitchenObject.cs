using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase
{
    public class KitchenObject : MonoBehaviour
    {
        [SerializeField] private KitchenObjectStaticData kitchenObjectData;

        public ClearCounter clearCounter;
    }
}