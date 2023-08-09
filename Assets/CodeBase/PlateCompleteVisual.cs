using System;
using System.Collections.Generic;
using System.Linq;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase
{
    public class PlateCompleteVisual : MonoBehaviour
    {
        [Serializable]
        private struct KitchenObjectGameObjectPair
        {
            public KitchenObjectStaticData data;
            public GameObject @object;
        }

        [SerializeField] private List<KitchenObjectGameObjectPair> pairs;

        private void Awake() => 
            Reset();

        public void OnIngredientAdded(KitchenObjectStaticData data) => 
            pairs.First(p => p.data == data).@object.SetActive(true);

        public void Reset() => 
            pairs.ForEach(p => p.@object.SetActive(false));
    }
}