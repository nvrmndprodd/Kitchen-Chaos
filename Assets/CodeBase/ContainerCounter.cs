using CodeBase.Characters;
using UnityEngine;

namespace CodeBase
{
    public class ContainerCounter : BaseCounter
    {
        [SerializeField] private ContainerCounterVisual visual;
        
        public override void Interact(Player player)
        {
            var kitchenObject = Instantiate(kitchenObjectData.prefab, counterTopContainer);
            kitchenObject.SetParent(player);
            
            visual.StartOpenCloseAnimation();
        }
    }
}