using System.Collections;
using UnityEngine;
using Zenject;

namespace TankGameCore
{
    public class SpawnSystem : MonoBehaviour
    {
        [SerializeField] private MonsterController[] monsters;
        [SerializeField] private Transform[] spawnPoints;

        [Inject] DiContainer container;
        [Inject] private SpawnSettings settings;

        private int monstersCount;

        public void Initialize()
        {
            monstersCount = 0;
            StartCoroutine(SpawnProcess());
        }

        private IEnumerator SpawnProcess()
        {
            while (true)
            {
                if (monstersCount < settings.MaxMonstersCount)
                {
                    CreateMonster();
                    yield return new WaitForSeconds(Random.Range(settings.MinSpawnDelay, settings.MinSpawnDelay));
                }

                yield return null;
            }
        }

        private void CreateMonster()
        {
            MonsterController prefab = monsters[Random.Range(0, monsters.Length)];
            Transform point = spawnPoints[Random.Range(0, spawnPoints.Length)];

            MonsterController monster = container.InstantiatePrefab(prefab).GetComponent<MonsterController>();
            monster.transform.position = point.position;

            monster.Initialize();
            monstersCount++;
        }
    }
}