using System;
using System.Collections.Generic;
using System.Linq;
using CodeBase.DataExtensions;
using CodeBase.KitchenObjects;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase
{
    // to make IUpdateListener and not MonoBehaviour 
    public class RecipeService : MonoBehaviour
    {
        public event Action RecipeAdded;
        
        [SerializeField] private RecipeServiceStaticData data;

        private readonly List<RecipeStaticData> _pendingRecipes = new List<RecipeStaticData>();
        private float _timer;

        public IReadOnlyList<RecipeStaticData> PendingRecipes => _pendingRecipes;

        private void Update()
        {
            if (_pendingRecipes.Count >= data.pendingRecipesMax) return;
            
            _timer += Time.deltaTime;

            if (_timer < data.spawnRecipeTimer) return;

            AddRandomRecipeToPending();
            _timer = 0;
        }

        public void DeliverRecipe(PlateKitchenObject plate)
        {
            foreach (var pendingRecipe in from pendingRecipe in _pendingRecipes
                     where pendingRecipe.kitchenObjects.Count == plate.KitchenObjects.Count
                     let ingredientMatches = pendingRecipe.kitchenObjects.All(ingredient => plate.KitchenObjects.Contains(ingredient))
                     where ingredientMatches
                     select pendingRecipe)
            {
                _pendingRecipes.Remove(pendingRecipe);
                RecipeAdded?.Invoke();
                return;
            }
        }

        private void AddRandomRecipeToPending()
        {
            _pendingRecipes.Add(data.availableRecipes.RandomItem());
            RecipeAdded?.Invoke();
        }
    }
}