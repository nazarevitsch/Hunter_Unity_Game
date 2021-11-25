namespace Behaviours
{
    using UnityEngine;
    public interface IVelocityProvider
    {
        Vector3 GetDesiredVelocity(float velocityLimit);
    }
}