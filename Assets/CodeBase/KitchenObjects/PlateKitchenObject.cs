using System.Collections.Generic;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.KitchenObjects
{
    public class PlateKitchenObject : KitchenObject
    {
        [SerializeField] private PlateVisualComponent visual;
        
        private List<KitchenObjectStaticData> _kitchenObjectsData;

        private PlateStaticData PlateData => Data as PlateStaticData;

        public IReadOnlyList<KitchenObjectStaticData> KitchenObjects => _kitchenObjectsData;

        private void Awake() => 
            _kitchenObjectsData = new List<KitchenObjectStaticData>();

        public bool TryAddIngredient(KitchenObjectStaticData data)
        {
            if (_kitchenObjectsData.Contains(data) || !PlateData.IsValidIngredient(data))
                return false;

            _kitchenObjectsData.Add(data);
            visual.OnIngredientAdded(data);
            return true;
        }
    }
}