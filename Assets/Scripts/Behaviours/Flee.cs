using System;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using UnityEngine;
namespace Behaviours
{
    public class Flee : BaseVelocityProvider
    {
        [SerializeField]
        public Transform objectToFlee; 
        
        [SerializeField]
        [Range(0, 10)]
        private float distanceToRun;

        [SerializeField]
        public List<IndividuumType> scareOf = new List<IndividuumType>();
        public override Vector3 GetDirectionVelocity(BaseIndividuum indiv) 
        {
            var result = Vector3.zero;
            var count = 0;
            foreach (var target in indiv.otherIndividuums.GetSpecificTypes(scareOf))
            {
                if (IsVisible(indiv, target))
                {
                    var direction = indiv.transform.position - target.transform.position;
                    result += direction.normalized;
                    count++;
                    Debug.DrawRay(indiv.transform.position, direction.normalized * 10, Color.red);
                }
            }

            if (count == 0) return indiv.Velocity / weigth;

            result /= count;
            return result.normalized * indiv.VelocityLimit;        
        }
        
        private bool IsVisible(BaseIndividuum indiv, BaseIndividuum target)
        {
            var distance = (indiv.transform.position - target.transform.position).sqrMagnitude;
            return distance < distanceToRun * distanceToRun;
        }
    }
}