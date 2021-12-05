using DefaultNamespace;

namespace Behaviours
{
    using UnityEngine;
    public abstract class BaseVelocityProvider : MonoBehaviour,  IVelocityProvider
    {
        [SerializeField]
        public int weigth = 1;
        
        public abstract Vector3 GetDirectionVelocity(BaseIndividuum indiv);
        
        public Vector3 VelocityToPosition(BaseIndividuum indiv, Vector3 position, float distance)
        {
            var direction = position - indiv.transform.position;
            var magnitude = direction.sqrMagnitude;

            var k = Mathf.Clamp01(magnitude / (distance * distance));
            return k * indiv.VelocityLimit * direction.normalized;
        }
    }
}