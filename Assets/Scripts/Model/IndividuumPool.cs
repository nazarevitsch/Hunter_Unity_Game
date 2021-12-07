using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DefaultNamespace.Model
{
    public class IndividuumPool : MonoBehaviour
    {
        public List<BaseIndividuum> Pool { get; }= new List<BaseIndividuum>();
        public delegate void OnKill (IndividuumType type);
        public event OnKill KillIndividuum;
        
        public List<BaseIndividuum> GetSpecificType(IndividuumType type)
        {
            return Pool.Where(individ => (individ.type & type) != 0).ToList(); 
        }
        
        public List<BaseIndividuum> GetSpecificTypes(List<IndividuumType> types)
        {
            return Pool.Where(individ => types.Contains(individ.type)).ToList(); 
        }

        public void Add(BaseIndividuum individuum)
        {
            individuum.otherIndividuums = this;
            Pool.Add(individuum);
        }

        public void Kill(BaseIndividuum individuum)
        {
            Pool.Remove(individuum);
            Destroy(individuum.gameObject);
            KillIndividuum?.Invoke(individuum.type);
        }
    }
}