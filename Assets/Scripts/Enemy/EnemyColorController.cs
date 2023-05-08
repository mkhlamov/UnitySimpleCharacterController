using System;
using UnityEngine;

namespace ITB.Enemy
{
    public class EnemyColorController : MonoBehaviour
    {
        [SerializeField] private Enemy enemy;
        [SerializeField] private Renderer[] enemyRendererList;

        private void Awake()
        {
            foreach (var enemyRenderer in enemyRendererList)
            {
                enemyRenderer.material.color = Color.green;
            }
        }

        private void OnEnable()
        {
            enemy.OnHealthChanged += UpdateColor;
        }

        private void OnDisable()
        {
            enemy.OnHealthChanged -= UpdateColor;
        }

        private void UpdateColor(float healthPercentage)
        {
            var newColor = Color.Lerp(Color.red, Color.green, healthPercentage);
            foreach (var enemyRenderer in enemyRendererList)
            {
                enemyRenderer.material.color = newColor;
            }
        }
    }
}