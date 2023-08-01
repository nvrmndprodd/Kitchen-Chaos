using UnityEngine;

namespace CodeBase
{
    public class ContainerCounter : BaseCounter
    {
        [SerializeField] private ContainerCounterVisual visual;
        
        public override void Interact(IKitchenObjectParent newParent)
        {
            if (newParent.HasKitchenObject) return;
            
            var kitchenObject = Instantiate(kitchenObjectData.prefab, counterTopContainer);
            kitchenObject.SetParent(newParent);
            
            visual.StartOpenCloseAnimation();
        }
    }
}