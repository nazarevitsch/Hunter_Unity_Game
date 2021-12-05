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
        [Range(30, 90)]
        private float angle = 45;
        
        [SerializeField]
        [Range(0, 70)]
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
            var pos = indiv.transform.position;
            var forward = Quaternion.AngleAxis((Random.value - 0.5f) * 2 * angle, indiv.transform.forward) * -indiv.transform.up;
            var predictSpeed = Time.fixedDeltaTime * indiv.VelocityLimit * forward;
            seekPosition = pos + predictSpeed * distance;
            count = countFrame;
            Debug.DrawLine(pos, seekPosition, Color.blue, countFrame * Time.fixedDeltaTime);
            return VelocityToPosition(indiv, seekPosition, distance);
        }
    }
}