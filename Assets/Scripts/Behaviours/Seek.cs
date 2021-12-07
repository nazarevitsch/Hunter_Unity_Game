using System;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
namespace Behaviours
{
    public class Seek : BaseVelocityProvider
    {

        [SerializeField]
        [Range(0, 10)]
        private float distanceToSeek = 1;
        
        [SerializeField]
        public List<IndividuumType> seekTo = new List<IndividuumType>();
        public override Vector3 GetDirectionVelocity(BaseIndividuum indiv)
        {
            BaseIndividuum closest = null;
            var len = distanceToSeek * distanceToSeek;
            var seekToList = indiv.otherIndividuums?.GetSpecificTypes(seekTo) ?? new List<BaseIndividuum>();
            foreach (var o in seekToList)
            {
                var distance = (indiv.transform.position - o.transform.position).sqrMagnitude;
                if (distance < len)
                {
                    len = distance;
                    closest = o;
                }
            }
            
            return closest ? VelocityToPosition(indiv, closest.transform.position, distanceToSeek) : indiv.Velocity / weigth;
        }
    }
}