using UnityEngine;

namespace TankGameCore
{
    [CreateAssetMenu(menuName = "SpawnData", fileName = "SpawnData")]
    public class SpawnData : ScriptableObject
    {
        [SerializeField] private int maxMonsters = 5;
        [SerializeField] private float minSpawnDelay = 1f;
        [SerializeField] private float maxSpawnDelay = 3f;

        public int MaxMonstersCount => maxMonsters;

        public float MinSpawnDelay => minSpawnDelay;

        public float MaxSpawnDelay => maxSpawnDelay;
    }
}