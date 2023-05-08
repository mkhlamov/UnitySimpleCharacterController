using System;
using System.Collections;
using ITB.ScriptableObjects;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ITB.Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyData data;

        public event Action<float> OnHealthChanged;

        private float currentHealth;
        private Vector3 currentDestination;
        private bool hasDestination;

        private void Awake()
        {
            currentHealth = data.maxHealth;
        }

        private void OnEnable()
        {
            NotifyOnHealthChanged();
        }

        private void Update()
        {
            Wander();
        }

        public void TakeDamage(float damage)
        {
            if (currentHealth <= 0)
            {
                return;
            }

            currentHealth -= damage;
            NotifyOnHealthChanged();

            if (currentHealth <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            Debug.Log("Enemy has died.");
            Destroy(gameObject);
        }

        private void NotifyOnHealthChanged()
        {
            OnHealthChanged?.Invoke(currentHealth / data.maxHealth);
        }

        private void Wander()
        {
            if (!hasDestination || IsObstacleInPath(currentDestination))
            {
                currentDestination = ChooseNewDestination();
                hasDestination = true;
            }

            transform.position =
                Vector3.MoveTowards(transform.position, currentDestination, data.wanderSpeed * Time.deltaTime);
            transform.LookAt(new Vector3(currentDestination.x, transform.position.y, currentDestination.z));

            if (Vector3.Distance(transform.position, currentDestination) < Mathf.Epsilon)
            {
                hasDestination = false;
            }
        }

        private Vector3 ChooseNewDestination()
        {
            var randomX = Random.Range(-1 * data.wanderRadius, data.wanderRadius);
            var randomZ = Random.Range(-1 * data.wanderRadius, data.wanderRadius);

            var newDestination = new Vector3(transform.position.x + randomX, transform.position.y,
                transform.position.z + randomZ);
            return newDestination;
        }

        private bool IsObstacleInPath(Vector3 destination)
        {
            return Physics.Raycast(transform.position, (destination - transform.position).normalized, out _,
                Vector3.Distance(transform.position, destination));
        }
    }
}