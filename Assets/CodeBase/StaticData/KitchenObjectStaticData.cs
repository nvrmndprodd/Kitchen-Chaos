using UnityEngine;

namespace CodeBase.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/KitchenObject", fileName = "KitchenObjectStaticData")]
    public class KitchenObjectStaticData : ScriptableObject
    {
        public KitchenObject.KitchenObject prefab;
        public Sprite icon;
        public string objectName;
        public bool canBeSliced;

        [HideInInspector] public KitchenObjectStaticData sliced;
        [HideInInspector] public int slicingProgressMaxValue;
    }
}