using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.DataExtensions
{
    public static class ListExtensions
    {
        public static T RandomItem<T>(this List<T> items) where T : class
        {
            return items.Count == 0 
                ? null
                : items[Random.Range(0, items.Count)];
        }
    }
}