using ITB.Player;
using ITB.ScriptableObjects;
using UnityEngine;

namespace PowerUp
{
    public class SpeedJumpBoostPowerUp : BasePowerUp
    {
        [SerializeField] private SpeedJumpBoostPowerUpData powerUpData;
        public override void Activate(Player player)
        {
            player.ApplySpeedJumpBoostPowerUp(powerUpData.speedBoostFactor, powerUpData.jumpBoostFactor);
        }

        public override void Deactivate(Player player)
        {
            player.ApplySpeedJumpBoostPowerUp(1 / powerUpData.speedBoostFactor, 1 / powerUpData.jumpBoostFactor);
        }

        protected override float GetCooldown()
        {
            return powerUpData.cooldown;
        }
    }
}