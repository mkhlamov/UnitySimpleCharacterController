using System;
using UnityEngine;

namespace ITB.Environment
{
    public class MovingPlatform : MonoBehaviour
    {
        [SerializeField] private Transform[] waypoints;
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] public float waitTimeAtWaypoints = 1f;

        private int currentWaypointIndex = 0;
        private float progress = 0f;
        private float waitTimeElapsed = 0f;
        private Vector3 previousPosition;
        private Vector3 currentVelocity;
        
        public Vector3 Velocity { get; private set; }

        private void Start()
        {
            if (waypoints.Length < 2)
            {
                Debug.LogError($"Fill in the point array in MovingPlatform.", this);
            }

            previousPosition = transform.position;
        }

        private void Update()
        {
            if (waypoints.Length < 2) return;

            if (waitTimeElapsed < waitTimeAtWaypoints)
            {
                waitTimeElapsed += Time.deltaTime;
                return;
            }

            progress += moveSpeed * Time.deltaTime;
            transform.position = Vector3.Lerp(waypoints[currentWaypointIndex].position, waypoints[GetNextWaypointIndex()].position, progress);

            currentVelocity = (transform.position - previousPosition) / Time.deltaTime;
            previousPosition = transform.position;

            if (progress >= 1f)
            {
                progress = 0f;
                waitTimeElapsed = 0f;
                currentWaypointIndex = GetNextWaypointIndex();
            }
        }
        
        public Vector3 GetCurrentVelocity()
        {
            return currentVelocity;
        }
        
        private int GetNextWaypointIndex()
        {
            return (currentWaypointIndex + 1) % waypoints.Length;
        }
    }
}