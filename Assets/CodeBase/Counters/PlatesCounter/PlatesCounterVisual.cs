using System.Collections.Generic;
using CodeBase.KitchenObjects;
using UnityEngine;

namespace CodeBase.Counters.PlatesCounter
{
    public class PlatesCounterVisual : MonoBehaviour
    {
        private const float PLATE_OFFSET_Y = 0.1f;
        
        private KitchenObject _platePrefab;
        private Transform _counterTopPoint;
        private Stack<KitchenObject> _plates;

        public int PlatesCount => _plates.Count;

        public void Construct(KitchenObject platePrefab, Transform counterTopPoint)
        {
            _platePrefab = platePrefab;
            _counterTopPoint = counterTopPoint;
            _plates = new Stack<KitchenObject>();
        }

        public void SpawnNewPlate()
        {
            var plate = Instantiate(_platePrefab, _counterTopPoint);
            plate.transform.localPosition = new Vector3(0, PLATE_OFFSET_Y * PlatesCount, 0);
            
            _plates.Push(plate);
        }

        public void RemoveOnePlate() => 
            Destroy(_plates.Pop().gameObject);
    }
}