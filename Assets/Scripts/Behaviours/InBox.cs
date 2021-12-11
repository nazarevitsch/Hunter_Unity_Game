using DefaultNamespace;
using UnityEngine;

namespace Behaviours
{
    public class InBox : BaseVelocityProvider
    {
        [SerializeField]
        [Range(0, 20)]
        private float avoidDistanceToEdge = 5;

        [SerializeField]
        private LayerMask avoidLayer;

        private readonly RaycastHit[] hits = new RaycastHit[3];
        private readonly RaycastHit[] raycast = new RaycastHit[1];

        public override Vector3 GetDirectionVelocity(BaseIndividuum indiv)
        {
            var pos = indiv.transform.position;
            var count = HitsNear(pos);
            if (count == 0) return indiv.Velocity / weigth;

            var v = Vector3.zero;
            for (var i = 0; i < count; i++)
            {
                var k = 1 - hits[i].distance / avoidDistanceToEdge;
                var target = hits[i].collider.transform.position;
                var position = indiv.transform.position;
                target.z = position.z;
                var distance = (target - position).magnitude * 1.1f;
                if (Raycast(indiv.transform.position, target, distance) > 0)
                {
                    v += indiv.velocityLimit * k * raycast[0].normal;
                }
            }
            return v / count;
        }

        private int HitsNear(Vector3 origin)
        {
            return Physics.SphereCastNonAlloc(origin, avoidDistanceToEdge, Vector3.right, hits, 0f, avoidLayer);
        }

        private int Raycast(Vector3 origin, Vector3 target, float distance)
        {
            var direction = (target - origin).normalized;
            return Physics.RaycastNonAlloc(origin, direction, raycast, distance);
        }
    }
}