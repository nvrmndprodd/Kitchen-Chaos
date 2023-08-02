using CodeBase.Infrastructure;
using CodeBase.KitchenObject;
using UnityEngine;

namespace CodeBase.Counters.CuttingCounter
{
    public class CuttingCounter : BaseCounter
    {
        [SerializeField] private CuttingCounterVisual visual;
        
        private int _cuttingProgress;

        public override void Interact(IKitchenObjectParent newParent)
        {
            if (!HasKitchenObject && newParent.HasKitchenObject && newParent.KitchenObject.CanBeSliced)
            {
                _cuttingProgress = 0;
                newParent.KitchenObject.SetParent(this);
                visual.EnableProgressBar();
            }
            else if (!newParent.HasKitchenObject)
                KitchenObject.SetParent(newParent);
        }

        public override void InteractAlternate(Player.Player player)
        {
            if (!HasKitchenObject || !KitchenObject.CanBeSliced) 
                return;

            ++_cuttingProgress;
            UpdateVisual();

            if (_cuttingProgress < KitchenObject.SlicingProgressMaxValue) 
                return;
            
            ReplaceKitchenObjectWithSliced();
            visual.DisableProgressBar();
        }

        private void UpdateVisual()
        {
            visual.UpdateProgress(_cuttingProgress, KitchenObject.SlicingProgressMaxValue);
            visual.StartCuttingAnimation();
        }

        private void ReplaceKitchenObjectWithSliced()
        {
            var slicedObject = KitchenObject.SlicedObject;
            KitchenObject.DestroySelf();
            GameFactory.CreateKitchenObject(slicedObject, this);
        }
    }
}