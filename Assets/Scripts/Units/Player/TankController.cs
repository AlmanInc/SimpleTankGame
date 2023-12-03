using UnityEngine.SceneManagement;
using UnityEngine;

namespace TankGameCore
{
    public class TankController : MonoBehaviour
    {
        [SerializeField] private UnitKinds kind;
        [SerializeField] private TankMovementController movementController;
        [SerializeField] private TankFireController fireController;
        [SerializeField] private HealthModule healthModule;

        private void Awake()
        {
            movementController.Initialize(kind);
            fireController.Initialize();
            healthModule.Initialize(kind);

            healthModule.OnDie += GameOver;
        }

        public void ApplyDamage(float damage)
        {
            healthModule.ApplyDamage(damage);
        }

        private void GameOver()
        {
            SceneManager.LoadSceneAsync("Start");
        }
    }
}