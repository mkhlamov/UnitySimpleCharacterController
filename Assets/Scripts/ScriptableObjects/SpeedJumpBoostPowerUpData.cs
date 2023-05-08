using UnityEngine;

namespace ITB.ScriptableObjects
{
    [CreateAssetMenu(fileName = "SpeedJumpBoostPowerUpData", menuName = "ITB/SpeedJumpBoostPowerUpData", order = 0)]
    public class SpeedJumpBoostPowerUpData : ScriptableObject
    {
        public float speedBoostFactor = 1.5f;
        public float jumpBoostFactor = 1.5f;
        public float cooldown = 5f;
    }
}