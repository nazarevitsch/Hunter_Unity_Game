using System;
using System.Collections.Generic;
using Behaviours;
using DefaultNamespace.Model;
using UnityEngine;

namespace DefaultNamespace
{
    public class BaseIndividuum : MonoBehaviour
    {
        public IndividuumType type = IndividuumType.None;

        public IndividuumPool otherIndividuums;

        public Vector3 Velocity { get; set; }

        public Vector3 Acceleration { get; set; }


        [SerializeField] public float AccelerationLimit = 10;

        [SerializeField] public float VelocityLimit = 10;

        private BaseVelocityProvider[] velocities;

        private void Start()
        {
            velocities = GetComponents<BaseVelocityProvider>();
        }

        public void Update()
        {
            ApplyFriction();

            ApplyVelocities();

            ApplyForces();
        }

        private void ApplyFriction()
        {
            ApplyForce(-(Velocity * 0.1f));
        }

        private void ApplyVelocities()
        {
            var accelerationSteering = Vector3.zero;
            foreach (var velocity in velocities)
            {
                accelerationSteering += velocity.GetDirectionVelocity(this) * velocity.weigth - Velocity;
            }

            ApplyForce(Vector3.ClampMagnitude(accelerationSteering, AccelerationLimit));
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
            var velocityRotation = Velocity;
            velocityRotation.z = 0;

            var z = Quaternion.LookRotation(velocityRotation, Vector3.forward).eulerAngles.x;
            transform.rotation = Quaternion.Euler(0, 0, z);
        }
    }
}