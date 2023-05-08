using ITB.ScriptableObjects;
using UnityEngine;

namespace Weapon
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] protected WeaponData weaponData;

        public abstract void Shoot();

        public abstract void ApplyDamageMultiplier(float damageMultiplier);
    }
}