using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class Predator : MonoBehaviour
    {
        [SerializeField] public List<IndividuumType> CanKill = new List<IndividuumType>();
        
        [SerializeField]
        public int Frames2Die = 6000;
        
        public int leftFrames;

        private void Start()
        {
            leftFrames = Frames2Die;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            var baseIndivid = other.gameObject.gameObject.GetComponent<BaseIndividuum>();
            if (baseIndivid != null && CanKill.Contains(baseIndivid.type))
            {
                baseIndivid.Kill();
                leftFrames = Frames2Die;
            }
        }

        private void Update()
        {
            leftFrames--;
            if (leftFrames < 0)
            {
                GetComponent<BaseIndividuum>().Kill();
            }
        }
    }
}