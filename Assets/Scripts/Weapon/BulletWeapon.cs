using ITB.Bullet;
using ITB.Enemy;
using ITB.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Weapon
{
    public abstract class BulletWeapon<TBullet> : Weapon
        where TBullet : Bullet
    {
        [SerializeField] protected Transform bulletSpawnPoint;

        private BulletPool<TBullet> bulletPool;
        private float damageMultiplier = 1;

        [Inject]
        public void Construct(BulletPool<TBullet> bulletPool)
        {
            this.bulletPool = bulletPool;
        }
        
        private float lastShotTime;

        private void Awake()
        {
            // Do this to be able to shoot instantly
            lastShotTime = Time.time - weaponData.cooldown;
        }

        public override void Shoot()
        {
            if (CanShoot())
            {
                MakeShot();
                lastShotTime = Time.time;
            }
        }

        public override void ApplyDamageMultiplier(float damageMultiplier)
        {
            this.damageMultiplier *= damageMultiplier;
        }

        private void MakeShot()
        {
            var bulletInstance = bulletPool.Spawn(weaponData, bulletSpawnPoint);
            bulletInstance.OnHit += HandleBulletHit;
        }

        private bool CanShoot()
        {
            return Time.time >= lastShotTime + weaponData.cooldown;
        }

        private void HandleBulletHit(Bullet bullet, Collision collision)
        {
            if (bullet is TBullet tBullet)
            {
                if (weaponData.isSplashDamage)
                {
                    var hitColliders = Physics.OverlapSphere(transform.position, weaponData.splashRadius);

                    foreach (var hitCollider in hitColliders)
                    {
                        ApplyDamage(hitCollider);
                    }
                }
                else
                {
                    ApplyDamage(collision.collider);
                }
                
                tBullet.OnHit -= HandleBulletHit;
                bulletPool.Despawn(tBullet);
            }
            else
            {
                Debug.LogError($"Failed to despawn a bullet. Got {bullet.GetType()} instead of FastBullet");
            }
        }

        private void ApplyDamage(Collider collider)
        {
            var enemy = collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(weaponData.damage * damageMultiplier);
            }
        }
    }
}