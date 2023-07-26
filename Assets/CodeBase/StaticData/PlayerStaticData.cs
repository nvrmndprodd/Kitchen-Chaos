using UnityEngine;

namespace CodeBase.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Player", fileName = "PlayerStaticData", order = 0)]
    public class PlayerStaticData : ScriptableObject
    {
        public float speed;
    }
}