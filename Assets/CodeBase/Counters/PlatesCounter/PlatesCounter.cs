using CodeBase.Infrastructure;
using CodeBase.KitchenObjects;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Counters.PlatesCounter
{
    public class PlatesCounter : BaseCounter
    {
        [SerializeField] private PlatesCounterStaticData data;
        [SerializeField] private PlatesCounterVisual visual;

        private float _timer;

        private void Awake()
        {
            visual.Construct(data.plateData.prefab, counterTopContainer);
        }

        private void Update()
        {
            _timer += Time.deltaTime;
            if (_timer <= data.spawnPlateTimer) return;
            
            _timer = 0;
            if (visual.PlatesCount < data.spawnedPlatesMax) 
                visual.SpawnNewPlate();
        }

        public override void Interact(IKitchenObjectParent newParent)
        {
            if (newParent.HasKitchenObject || visual.PlatesCount <= 0) 
                return;
            
            visual.RemoveOnePlate();
            GameFactory.CreateKitchenObject(data.plateData, newParent);
        }
    }
}