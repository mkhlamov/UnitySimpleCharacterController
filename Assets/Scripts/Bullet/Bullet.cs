using System;
using ITB.ScriptableObjects;

namespace ITB.Bullet
{
    using Zenject;
    using UnityEngine;

    public abstract class Bullet : MonoBehaviour
    {
        public event Action<Bullet, Collision> OnHit;
            
        private WeaponData weaponData;
        private Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        public void Initialize(WeaponData weaponData, Transform spawnPoint)
        {
            this.weaponData = weaponData;
            transform.position = spawnPoint.position;
            transform.rotation = spawnPoint.rotation;
            rb.velocity = spawnPoint.forward * weaponData.bulletSpeed;
        }

        private void OnCollisionEnter(Collision collision)
        {
            OnHit?.Invoke(this, collision);
        }

    }
}