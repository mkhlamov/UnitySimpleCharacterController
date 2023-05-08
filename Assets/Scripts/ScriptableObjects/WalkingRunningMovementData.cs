using UnityEngine;

namespace ITB.ScriptableObjects
{
    [CreateAssetMenu(fileName = "WalkingRunningMovementData", menuName = "ITB/WalkingRunningMovementData", order = 0)]
    public class WalkingRunningMovementData : ScriptableObject
    {
        public bool isDefault = true;
        public float moveSpeed = 5f;
        public float maxSpeed = 10f;
        public float gravity = -13.0f;
        public float jumpHeight = 1.2f;
        public float accelerationFactor = 2f;
        public float mouseSensitivity = 100f;
        public float cameraUpVerticalLimit = 90f;
        public float cameraDownVerticalLimit = 90f;
        public bool invertY = true;
        public float playerRadius = 0.5f;
        public float playerHeight = 2f;
        public float stairStepHeight = .7f;
        public LayerMask groundLayers;
        public LayerMask edgeLayers;
    }
}