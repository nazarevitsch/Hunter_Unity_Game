using System;
using System.Collections.Generic;
using UnityEngine;
using DefaultNamespace;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace DefaultNamespace.Model
{
    public class SimpleSpavner : MonoBehaviour
    {
        [SerializeField] 
        private BaseIndividuum player;
        
        [SerializeField] 
        private List<BaseIndividuum> prefabs = new List<BaseIndividuum>();

        [FormerlySerializedAs("HareCount")] [SerializeField] [Range(0, 50)] private int hareCount;
        [FormerlySerializedAs("DeerGroupsCount")] [SerializeField] [Range(0, 50)] private int deerGroupsCount;
        [FormerlySerializedAs("WolfCount")] [SerializeField] [Range(0, 50)] private int wolfCount;
        [SerializeField] [Range(0, 200)] private int spawnRadius = 100;
        
        private IndividuumPool _pool;

        private void Start()
        {
            _pool = gameObject.AddComponent<IndividuumPool>();
            _pool.KillIndividuum += Respawn;
            _pool.Add(player);
            
            foreach (var baseIndividuum in prefabs)
            {
                switch (baseIndividuum.type)
                {
                    case IndividuumType.Hare:
                        SpawnHares(baseIndividuum);
                        break;
                    case IndividuumType.Wolf:
                        SpawnWolfs(baseIndividuum);
                        break;
                    case IndividuumType.Deer:
                        SpawnDeers(baseIndividuum);
                        break;
                    default:
                        continue;
                }
            }
        }

        private void SpawnHares(BaseIndividuum prefab)
        {
            for (var i = 0; i < hareCount; i++)
            {
                RandomSpawn(prefab);
            }
        }

        private void SpawnWolfs(BaseIndividuum prefab)
        {
            for (var i = 0; i < wolfCount; i++)
            {
                RandomSpawn(prefab);
            }
        }

        private void SpawnDeers(BaseIndividuum prefab)
        {
            for (var i = 0; i < deerGroupsCount; i++)
            {
                SpawnGroup(prefab, Random.Range(3, 5));
            }
        }

        private void Respawn(IndividuumType type)
        {
            foreach (var baseIndividuum in prefabs)
            {
                if (baseIndividuum.type == type)
                {
                    RandomSpawn(baseIndividuum);
                    return;
                }
            }
        }

        private void RandomSpawn(BaseIndividuum prefab)
        {
            var random = Random.insideUnitCircle * spawnRadius;
            var position = new Vector3(random.x, 0, random.y);
            _pool.Add(Instantiate(prefab, position, Random.rotation));
        }

        private void SpawnGroup(BaseIndividuum prefab, int size)
        {
            var random = Random.insideUnitCircle * spawnRadius;
            var position = new Vector3(random.x, 0, random.y);
            _pool.Add(Instantiate(prefab, position, Random.rotation));
            for (int i = 0; i < size - 1; i++)
            {
                _pool.Add(Instantiate(prefab, position + Random.onUnitSphere, Random.rotation));
            }
            
        }
    }
}