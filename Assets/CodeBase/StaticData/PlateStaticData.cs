using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Plate", fileName = "PlateStaticData")]
    public class PlateStaticData : KitchenObjectStaticData
    {
        [SerializeField] private List<KitchenObjectStaticData> canBePutOnPlate;

        public bool IsValidIngredient(KitchenObjectStaticData data) => 
            canBePutOnPlate.Contains(data);
    }
}