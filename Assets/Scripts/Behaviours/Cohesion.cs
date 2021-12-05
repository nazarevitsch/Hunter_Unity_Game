using System;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using UnityEngine;
namespace Behaviours
{
    public class Cohesion : BaseVelocityProvider
    {

        [SerializeField]
        [Range(0, 10)]
        private float cohesionRadius = 1;
        
        [SerializeField]
        public List<IndividuumType> seekTo = new List<IndividuumType>();
        public override Vector3 GetDirectionVelocity(BaseIndividuum indiv)
        {
            var result = Vector3.zero;
            var count = 0;

            foreach (var target in indiv.otherIndividuums.GetSpecificTypes(seekTo))
            {
                var distance = (target.transform.position - indiv.transform.position).sqrMagnitude;
                if (distance < cohesionRadius * cohesionRadius)
                {
                    result += target.transform.position;
                    count++;
                }
            }

            if (count == 0) return indiv.Velocity / weigth;

            result /= count;
            Debug.DrawLine(indiv.transform.position, result, Color.green, 0.03f);
            return VelocityToPosition(indiv, result, cohesionRadius);
        }
    }
}