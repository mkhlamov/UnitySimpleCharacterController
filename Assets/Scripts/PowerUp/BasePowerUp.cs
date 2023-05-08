using System.Collections;
using ITB.Player;
using UnityEngine;
using Zenject;

namespace PowerUp
{
    public abstract class BasePowerUp : MonoBehaviour
    {
        [SerializeField] private GameObject powerUpVisual;

        private bool isAvailable = true;
        private Player player;

        protected virtual void OnTriggerEnter(Collider other)
        {
            if (isAvailable && other.TryGetComponent<Player>(out var player))
            {
                this.player = player;
                isAvailable = false;
                powerUpVisual.SetActive(false);
                Activate(player);
                StartCoroutine(WaitForCooldown());
            }
        }

        public abstract void Activate(Player player);
        public abstract void Deactivate(Player player);
        protected abstract float GetCooldown();

        private IEnumerator WaitForCooldown()
        {
            yield return new WaitForSeconds(GetCooldown());
            powerUpVisual.SetActive(true);
            isAvailable = true;
            Deactivate(player);
            
        }
    }
}