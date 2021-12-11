using System;
using System.Collections.Generic;
using Behaviours;
using DefaultNamespace.Model;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    public class BaseIndividuum : MonoBehaviour
    {
        public IndividuumType type = IndividuumType.None;
        public IndividuumPool otherIndividuums;
        public Vector3 Velocity { get; set; }
        public Vector3 Acceleration { get; set; }

        [FormerlySerializedAs("AccelerationLimit")] [SerializeField] public float accelerationLimit = 10;
        [FormerlySerializedAs("VelocityLimit")] [SerializeField] public float velocityLimit = 10;
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

            ApplyForce(Vector3.ClampMagnitude(accelerationSteering, accelerationLimit));
        }

        private void ApplyForce(Vector3 force)
        {
            Acceleration += force;
        }

        private void ApplyForces()
        {
            Velocity += Acceleration * Time.deltaTime;
            Velocity = Vector3.ClampMagnitude(Velocity, velocityLimit);
            
            if (Velocity.magnitude < 0.05f)
            {
                Velocity = Vector3.zero;
                return;
            }

            transform.position += Velocity * Time.deltaTime;
            Acceleration = Vector3.zero;
            var velocityRotation = Velocity;
            velocityRotation.z = 0;
            var newPos = transform.position;
            newPos.z = 0;
            transform.position = newPos;
            if (type != IndividuumType.Player)
            {
                var z = Quaternion.LookRotation(velocityRotation, Vector3.forward).eulerAngles.x;
                transform.rotation = Quaternion.Euler(0, 0, z);
            }
        }

        public void Kill()
        {
            otherIndividuums?.Kill(this);
        }
    }
}