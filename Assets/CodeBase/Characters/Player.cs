using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Characters
{
    public class Player : MonoBehaviour
    {
        public PlayerStaticData data;
        
        private void Update()
        {
            var inputVector = Vector3.zero;

            inputVector.x = Input.GetAxis("Horizontal");
            inputVector.y = Input.GetAxis("Vertical");
            
            inputVector.Normalize();

            var direction = new Vector3(inputVector.x, 0f, inputVector.y);
            transform.Translate(direction * (Time.deltaTime * data.speed));
        }
    }
}