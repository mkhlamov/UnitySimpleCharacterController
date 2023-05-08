using UnityEngine;

namespace ITB.ScriptableObjects
{
    
    [CreateAssetMenu(fileName = "WeaponData", menuName = "ITB/WeaponData")]
    public class WeaponData : ScriptableObject
    {
        public float damage;
        public float bulletSpeed;
        public bool isSplashDamage;
        public float splashRadius;
        public float cooldown;
    }
}