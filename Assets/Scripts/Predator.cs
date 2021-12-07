using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class Predator : MonoBehaviour
    {
        [SerializeField] public List<IndividuumType> CanKill = new List<IndividuumType>();
        private void OnCollisionEnter2D(Collision2D other)
        {
            var baseIndivid = other.gameObject.gameObject.GetComponent<BaseIndividuum>();
            if (baseIndivid != null && CanKill.Contains(baseIndivid.type))
            {
                baseIndivid.Kill();
            }
        }
    }
}