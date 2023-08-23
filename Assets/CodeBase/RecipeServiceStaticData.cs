using System.Collections.Generic;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase
{
    [CreateAssetMenu(menuName = "StaticData/RecipeService", fileName = "RecipeServiceStaticData")]
    public class RecipeServiceStaticData : ScriptableObject
    {
        public List<RecipeStaticData> availableRecipes;
        public float spawnRecipeTimer;
        public int pendingRecipesMax;
    }
}