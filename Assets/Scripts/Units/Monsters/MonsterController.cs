using UnityEngine;

namespace TankGameCore
{
    public class MonsterController : MonoBehaviour
    {
        [SerializeField] private UnitKinds kind;
        [SerializeField] private MonsterMovementController movementController;
        [SerializeField] private HealthModule healthModule;

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
            Destroy(this.gameObject);
        }
    }
}