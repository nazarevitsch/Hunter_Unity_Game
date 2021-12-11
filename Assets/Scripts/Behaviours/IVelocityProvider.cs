using DefaultNamespace;

namespace Behaviours
{
    using UnityEngine;
    public interface IVelocityProvider
    {
        Vector3 GetDirectionVelocity(BaseIndividuum indiv);
    }
}