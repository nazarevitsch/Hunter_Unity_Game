using System.Collections.Generic;
using UnityEngine;
using DefaultNamespace;

namespace DefaultNamespace.Model
{
    public class SimpleSpavner : MonoBehaviour
    {
        [SerializeField] 
        private List<BaseIndividuum> prefabs = new List<BaseIndividuum>();
        
        [SerializeField] 
        private List<int> amounts = new List<int>();
        private void Start()
        {
            IndividuumPool pool = new IndividuumPool();
            for (var i = 0; i < prefabs.Count; i++)
            {
                for (var j = 0; j < amounts[i]; j++)
                {
                    var individ = Instantiate(prefabs[i], Vector3.zero, Random.rotation);
                    individ.otherIndividuums = pool;
                    pool.pool.Add(individ);
                }
            }
        }
    }
}