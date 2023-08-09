using System.Collections.Generic;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.KitchenObjects
{
    public class PlateKitchenObject : KitchenObject
    {
        [SerializeField] private PlateCompleteVisual completeVisual;
        
        private List<KitchenObjectStaticData> _kitchenObjectsData;

        private PlateStaticData PlateData => Data as PlateStaticData;

        private void Awake() => 
            _kitchenObjectsData = new List<KitchenObjectStaticData>();

        public bool TryAddIngredient(KitchenObjectStaticData data)
        {
            if (_kitchenObjectsData.Contains(data) || !PlateData.IsValidIngredient(data))
            {
                return false;
            }
            else
            {
                _kitchenObjectsData.Add(data);
                completeVisual.OnIngredientAdded(data);
                return true;
            }
        }
    }
}