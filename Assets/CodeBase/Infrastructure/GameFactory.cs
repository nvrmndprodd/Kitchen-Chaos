using CodeBase.KitchenObject;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public static class GameFactory
    {
        public static KitchenObject.KitchenObject CreateKitchenObject(KitchenObjectStaticData data, IKitchenObjectParent parent)
        {
            var kitchenObject = Object.Instantiate(data.prefab, parent.KitchenObjectContainer);
            kitchenObject.SetParent(parent);

            return kitchenObject;
        }
    }
}