using UnityEngine;

namespace ITB.ScriptableObjects
{
    
    [CreateAssetMenu(fileName = "DamagePowerUpData", menuName = "ITB/DamagePowerUpData", order = 0)]
    public class DamagePowerUpData : ScriptableObject
    {
        public float damageMultiplier = 1.5f;
        public float duration = 5f;
    }
}