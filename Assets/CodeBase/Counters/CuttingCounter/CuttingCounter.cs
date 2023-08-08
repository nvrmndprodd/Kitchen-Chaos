using CodeBase.Infrastructure;
using CodeBase.KitchenObjects;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Counters.CuttingCounter
{
    public class CuttingCounter : BaseCounter
    {
        [SerializeField] private CuttingCounterVisual visual;

        private KitchenObjectStaticData _uncutObjectData;
        private int _cuttingProgress;

        public override void Interact(IKitchenObjectParent newParent)
        {
            if (!HasKitchenObject)
            {
                if (newParent.HasKitchenObject && newParent.KitchenObject.Data.canBeSliced)
                {
                    _cuttingProgress = 0;
                    newParent.KitchenObject.SetParent(this);
                    _uncutObjectData = KitchenObject.Data;
                    visual.EnableProgressBar();
                }
            }
            else
            {
                if (newParent.HasKitchenObject)
                {
                    if (newParent.KitchenObject is PlateKitchenObject plate)
                    {
                        if (plate.TryAddIngredient(KitchenObject.Data))
                            KitchenObject.DestroySelf();
                    }
                    
                    if (KitchenObject is PlateKitchenObject p)
                    {
                        if (p.TryAddIngredient(newParent.KitchenObject.Data))
                            newParent.KitchenObject.DestroySelf();
                    }
                }
                else
                {
                    KitchenObject.SetParent(newParent);
                }
            }
        }

        public override void InteractAlternate()
        {
            if (!HasKitchenObject || !_uncutObjectData.canBeSliced) 
                return;

            ++_cuttingProgress;
            UpdateVisual();

            if (_cuttingProgress < _uncutObjectData.slicingProgressMaxValue) 
                return;
            
            ReplaceKitchenObjectWithSliced();
            visual.DisableProgressBar();
        }

        private void UpdateVisual()
        {
            visual.UpdateProgress(_cuttingProgress, _uncutObjectData.slicingProgressMaxValue);
            visual.StartCuttingAnimation();
        }

        private void ReplaceKitchenObjectWithSliced()
        {
            KitchenObject.DestroySelf();
            GameFactory.CreateKitchenObject(_uncutObjectData.sliced, this);
        }
    }
}