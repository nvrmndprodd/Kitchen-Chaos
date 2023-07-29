using UnityEngine;

namespace CodeBase.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Player", fileName = "PlayerStaticData", order = 0)]
    public class PlayerStaticData : ScriptableObject
    {
        public float playerRadius = .7f;
        public float playerHeight = 2f;
        public float speed;
        public float rotationSpeed;
    }
}