using ITB.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace ITB.Bullet
{
    public class BulletPool<T> : MonoMemoryPool<WeaponData, Transform, T> where T: Bullet
    {
        protected override void Reinitialize(WeaponData weaponData, Transform spawnPoint, T bullet)
        {
            bullet.Initialize(weaponData, spawnPoint);
        }
    }
    
    public class FastBulletPool : BulletPool<FastBullet> { }
    
    public class SlowBulletPool : BulletPool<SlowBullet> { }
}