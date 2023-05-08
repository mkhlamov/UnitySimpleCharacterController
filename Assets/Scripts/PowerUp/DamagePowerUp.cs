using ITB.Player;
using ITB.ScriptableObjects;
using UnityEngine;

namespace PowerUp
{
    public class DamagePowerUp : BasePowerUp
    {
        [SerializeField] private DamagePowerUpData damagePowerUpData; 
        public override void Activate(Player player)
        {
            player.ApplyDamageMultiplier(damagePowerUpData.damageMultiplier);
        }

        public override void Deactivate(Player player)
        {
            player.ApplyDamageMultiplier(1 / damagePowerUpData.damageMultiplier);
        }

        protected override float GetCooldown()
        {
            return damagePowerUpData.duration;
        }
    }
}