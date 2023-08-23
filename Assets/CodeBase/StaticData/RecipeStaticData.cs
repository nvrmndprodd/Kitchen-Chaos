using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Recipe", fileName = "RecipeStaticData")]
    public class RecipeStaticData : ScriptableObject
    {
        public List<KitchenObjectStaticData> kitchenObjects;
        public string recipeTitle;
    }
}