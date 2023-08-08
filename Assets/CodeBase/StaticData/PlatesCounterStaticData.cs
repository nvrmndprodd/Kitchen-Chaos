using UnityEngine;

namespace CodeBase.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/PlatesCounter", fileName = "PlatesCounterStaticData")]
    public class PlatesCounterStaticData : ScriptableObject
    {
        public KitchenObjectStaticData plateData;
        public float spawnPlateTimer = 4;
        public int spawnedPlatesMax = 3;
    }
}