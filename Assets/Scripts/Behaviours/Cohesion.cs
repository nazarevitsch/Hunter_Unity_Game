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

            var seekToList = indiv.otherIndividuums?.GetSpecificTypes(seekTo) ?? new List<BaseIndividuum>();
            foreach (var target in seekToList)
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
            return VelocityToPosition(indiv, result, cohesionRadius);
        }
    }
}