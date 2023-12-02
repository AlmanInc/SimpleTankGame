using UnityEngine;
using Zenject;

namespace TankGameCore
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private TankController tankController;        
        [SerializeField] private Transform[] playerSpawnPoints;

        [Space]
        [SerializeField] private SpawnSystem spawnSystem;

        [Inject] DiContainer container;

        public TankController Player { get; private set; }

        private void Awake()
        {
            Player = container.InstantiatePrefab(tankController).GetComponent<TankController>();
            Player.transform.position = playerSpawnPoints[Random.Range(0, playerSpawnPoints.Length)].position;
        }

        private void Start()
        {
            spawnSystem.Initialize();
        }
    }
}