using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DefaultNamespace.Model
{
    public class IndividuumPool : MonoBehaviour
    {
        public List<BaseIndividuum> pool = new List<BaseIndividuum>();

        public List<BaseIndividuum> GetSpecificType(IndividuumType type)
        {
            return pool.Where(individ => (individ.type & type) != 0).ToList(); 
        }
        
        public List<BaseIndividuum> GetSpecificTypes(List<IndividuumType> types)
        {
            return pool.Where(individ => types.Contains(individ.type)).ToList(); 
        }
    }
}