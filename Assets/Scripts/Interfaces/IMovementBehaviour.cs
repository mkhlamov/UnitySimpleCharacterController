using System;
using ITB.Player;
using UnityEngine;

namespace ITB.Interfaces
{
    public interface IMovementBehaviour
    {
        public event Action<PlayerState> OnMovementStateChanged;
        MovementType MovementType { get; }
        bool IsDefault { get; }

        (Vector3 position, Quaternion rotation) UpdatePositionAndRotation(Vector3 position, Quaternion startRotation, Collider collider);
        Quaternion RotateCamera();

        void OnEnable();
        void OnDisable();

        void ApplyPowerUp(ScriptableObject powerUpData);
    }
}