using System;
using Behaviours;
using UnityEngine;

namespace DefaultNamespace
{
    public class AnimalScript : MonoBehaviour
    {
        
        private Vector3 Velocity { get; set; }

        private Vector3 Acceleration { get;  set; }

        [SerializeField] public float AccelerationLimit = 10;
        [SerializeField] public float VelocityLimit = 10;
        
        public void Update()
        {
            ApplyFriction();
            
            ApplyVelocities();
            
            ApplyForces();
        }

        private void ApplyFriction()
        {
            ApplyForce(-(Velocity.normalized * 0.1f));
        }

        private void ApplyVelocities()
        {
            var accelerationSteering = Vector3.zero;
            var velocities = GetComponents<BaseVelocityProvider>();
            foreach (var velocity in velocities)
            {
                accelerationSteering += velocity.GetDesiredVelocity(VelocityLimit) - Velocity;
            }

            ApplyForce(Vector3.ClampMagnitude(accelerationSteering - Velocity, AccelerationLimit));
        }

        private void ApplyForce(Vector3 force)
        {
            Acceleration += force;
        }
        
        private void ApplyForces()
        {
            Velocity += Acceleration * Time.deltaTime;
            //limit velocity
            Velocity = Vector3.ClampMagnitude(Velocity, VelocityLimit);

            //on small values object might start to blink, so we considering 
            //small velocities as zeroes
            if (Velocity.magnitude < 0.05f)
            {
                Velocity = Vector3.zero;
                return;
            }

            transform.position += Velocity * Time.deltaTime;
            Acceleration = Vector3.zero;
        }
    }
}