using System;
using UnityEngine;
namespace Behaviours
{
    public class Flee : BaseVelocityProvider
    {
        [SerializeField]
        public Transform objectToFlee; 
        public override Vector3 GetDesiredVelocity(float velocityLimit) {
            return -(objectToFlee.position - transform.transform.position).normalized * velocityLimit;
        }
    }
}