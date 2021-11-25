using System;
using UnityEngine;
namespace Behaviours
{
    public class Seek : BaseVelocityProvider
    {
        [SerializeField]
        public Transform objectToSeek; 
        public override Vector3 GetDesiredVelocity(float velocityLimit) {
            return (objectToSeek.transform.position - transform.position).normalized * velocityLimit;
        }
    }
}