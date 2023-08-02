using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase
{
    public class ContainerCounter : BaseCounter
    {
        [SerializeField] private KitchenObjectStaticData kitchenObjectData;
        [SerializeField] private ContainerCounterVisual visual;
        
        public override void Interact(IKitchenObjectParent newParent)
        {
            if (newParent.HasKitchenObject) return;

            GameFactory.CreateKitchenObject(kitchenObjectData, newParent);
            
            visual.StartOpenCloseAnimation();
        }
    }
}