using UnityEngine;
using Zenject;

namespace TankGameCore
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private TankController tankController;
        [SerializeField] private Transform[] playerSpawnPoints;

        [Inject] DiContainer container;

        public TankController Player { get; private set; }

        private void Start()
        {
            Player = container.InstantiatePrefab(tankController).GetComponent<TankController>();
            Player.transform.position = playerSpawnPoints[Random.Range(0, playerSpawnPoints.Length)].position;
        }
    }
}