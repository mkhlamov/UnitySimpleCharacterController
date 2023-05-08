using ITB.Environment;
using UnityEngine;
using Zenject;

namespace ITB.Player
{
    public class PlayerStickToMovingPlatform : MonoBehaviour
    {
        [SerializeField] private LayerMask movingPlatformLayer;

        private const float GroundCheckDistance = 0.2f;
        private const float GroundedOffset = 0.1f;

        private void Update()
        {
            CheckForMovingPlatform();
        }

        private void CheckForMovingPlatform()
        {
            var spherePosition = new Vector3(transform.position.x, transform.position.y + GroundedOffset,
                transform.position.z);
            if (Physics.Raycast(spherePosition, Vector3.down, out var hit, GroundCheckDistance, movingPlatformLayer))
            {
                if (hit.collider.TryGetComponent<MovingPlatform>(out var movingPlatform) && transform.parent != movingPlatform.transform)
                {
                    transform.SetParent(movingPlatform.transform);
                }
            }
            else
            {
                if (transform.parent != null)
                {
                    transform.SetParent(null);
                }
            }
        }
    }
}