using UnityEngine;

namespace ITB.ScriptableObjects
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "ITB/EnemyData", order = 1)]
    public class EnemyData : ScriptableObject
    {
        public float maxHealth = 200;
        public float wanderRadius = 5f;
        public float wanderSpeed = 1f;
    }
}