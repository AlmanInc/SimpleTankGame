using UnityEngine;

namespace TankGameCore
{
    [CreateAssetMenu(menuName = "SpawnSettings", fileName = "SpawnSettings")]
    public class SpawnSettings : ScriptableObject
    {
        [SerializeField] private int maxMonsters = 5;
        [SerializeField] private float minSpawnDelay = 1f;
        [SerializeField] private float maxSpawnDelay = 3f;

        public int MaxMonstersCount => maxMonsters;

        public float MinSpawnDelay => minSpawnDelay;

        public float MaxSpawnDelay => maxSpawnDelay;
    }
}