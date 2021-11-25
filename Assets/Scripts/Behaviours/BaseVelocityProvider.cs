namespace Behaviours
{
    using UnityEngine;
    public abstract class BaseVelocityProvider : MonoBehaviour,  IVelocityProvider
    {
        public abstract Vector3 GetDesiredVelocity(float velocityLimit);
    }
}