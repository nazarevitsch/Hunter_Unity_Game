using DefaultNamespace;
using UnityEngine;

namespace Behaviours
{
    public class ManualVelocityProvider : BaseVelocityProvider
    {
        public override Vector3 GetDirectionVelocity(BaseIndividuum indiv)
        {
            var finalVelocity = Vector3.zero;
            if (Input.GetKey(KeyCode.S))
            {
                finalVelocity += Vector3.down;
            }
            if (Input.GetKey(KeyCode.W))
            {
                finalVelocity += Vector3.up;
            }
            if (Input.GetKey(KeyCode.D))
            {
                finalVelocity += Vector3.right;
            }
            if (Input.GetKey(KeyCode.A))
            {
                finalVelocity += Vector3.left;
            }

            finalVelocity.Normalize();
            finalVelocity *= indiv.velocityLimit;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                finalVelocity *= 2;
            }

            return finalVelocity;
        }
    }
}