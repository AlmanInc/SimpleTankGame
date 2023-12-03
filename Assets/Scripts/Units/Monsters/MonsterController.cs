using UnityEngine;
using Zenject;

namespace TankGameCore
{
    public class MonsterController : MonoBehaviour
    {
        [SerializeField] private UnitKinds kind;
        [SerializeField] private MonsterMovementController movementController;
        [SerializeField] private HealthModule healthModule;

        [Inject] private EventsManager eventsManager;

        public void Initialize()
        {
            movementController.Initialize(kind);
            healthModule.Initialize(kind);

            healthModule.OnDie -= KillMonster;
            healthModule.OnDie += KillMonster;
        }

        public void ApplyDamage(float damage)
        {
            healthModule.ApplyDamage(damage);
        }

        private void KillMonster()
        {
            eventsManager.InvokeEvent(GameEvents.OnKillOneMonster);
            Destroy(this.gameObject);
        }
    }
}