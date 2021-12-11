using System;
using System.Collections.Generic;
using UnityEngine;
using DefaultNamespace;
using Random = UnityEngine.Random;

namespace DefaultNamespace.Model
{
    public class SimpleSpavner : MonoBehaviour
    {
        [SerializeField] 
        private BaseIndividuum player;
        
        [SerializeField] 
        private List<BaseIndividuum> prefabs = new List<BaseIndividuum>();

        [SerializeField] [Range(0, 50)] private int HareCount;
        [SerializeField] [Range(0, 50)] private int DeerGroupsCount;
        [SerializeField] [Range(0, 50)] private int WolfCount;
        [SerializeField] [Range(0, 200)] private int spawnRadius = 100;
        
        private IndividuumPool _pool = new IndividuumPool();

        private void Start()
        {
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
            for (var i = 0; i < HareCount; i++)
            {
                RandomSpawn(prefab);
            }
        }

        private void SpawnWolfs(BaseIndividuum prefab)
        {
            for (var i = 0; i < WolfCount; i++)
            {
                RandomSpawn(prefab);
            }
        }

        private void SpawnDeers(BaseIndividuum prefab)
        {
            for (var i = 0; i < DeerGroupsCount; i++)
            {
                SpawnGroup(prefab, Random.Range(3, 5));
            }
        }

        private void Respawn(IndividuumType type) // Maybe this can be slow and we will need to optimize it latter.
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