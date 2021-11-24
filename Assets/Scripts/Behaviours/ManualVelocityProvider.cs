using UnityEngine;

namespace Behaviours
{
    public class ManualVelocityProvider : BaseVelocityProvider
    {
        public override Vector3 GetDesiredVelocity(float velocityLimit)
        {
            var finalVelocity = Vector3.zero;
            if (Input.GetKey(KeyCode.S))
            {
                finalVelocity += Vector3.down * velocityLimit;
            }
            if (Input.GetKey(KeyCode.W))
            {
                finalVelocity += Vector3.up * velocityLimit;
            }
            if (Input.GetKey(KeyCode.D))
            {
                finalVelocity += Vector3.right * velocityLimit;
            }
            if (Input.GetKey(KeyCode.A))
            {
                finalVelocity += Vector3.left * velocityLimit;
            }

            return finalVelocity;
        }
    }
}