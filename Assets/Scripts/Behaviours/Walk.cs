using System;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Behaviours
{
    public class Walk : BaseVelocityProvider
    {
        [SerializeField]
        [Range(1, 10)]
        private float distance = 1;
        
        [SerializeField]
        [Range(30, 180)]
        private float angle = 45;
        
        [SerializeField]
        [Range(0, 1000)]
        private int countFrame = 30;

        private int count;
        private Vector3 seekPosition = new Vector3();
        public override Vector3 GetDirectionVelocity(BaseIndividuum indiv) 
        {
            if (count > 0)
            {
                count--;
                return VelocityToPosition(indiv, seekPosition,distance);
            }

            var transform1 = indiv.transform;
            var pos = transform1.position;
            var forward = Quaternion.AngleAxis((Random.value - 0.5f) * 2 * angle, transform1.forward) * -transform1.up;
            var predictSpeed = Time.fixedDeltaTime * indiv.velocityLimit * forward;
            seekPosition = pos + predictSpeed * distance;
            count = countFrame;
            return VelocityToPosition(indiv, seekPosition, distance);
        }
    }
}