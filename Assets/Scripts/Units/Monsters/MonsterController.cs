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
        [Inject] private MonstersDamageStorage damageStorage;

        private float damage;

        public void Initialize()
        {
            movementController.Initialize(kind);
            healthModule.Initialize(kind);

            healthModule.OnDie -= KillMonster;
            healthModule.OnDie += KillMonster;

            damage = damageStorage.GetItem(kind);
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

        private void OnCollisionEnter(Collision collision)
        {
            TankController target = collision.gameObject.GetComponent<TankController>();

            if (target != null)
            {
                target.ApplyDamage(damage);

                eventsManager.InvokeEvent(GameEvents.OnKillOneMonster);
                Destroy(this.gameObject);
            }
        }
    }
}