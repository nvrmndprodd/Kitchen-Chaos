using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase
{
    public static class GameFactory
    {
        public static KitchenObject CreateKitchenObject(KitchenObjectStaticData data, IKitchenObjectParent parent)
        {
            var kitchenObject = Object.Instantiate(data.prefab, parent.KitchenObjectContainer);
            kitchenObject.SetParent(parent);

            return kitchenObject;
        }
    }
}