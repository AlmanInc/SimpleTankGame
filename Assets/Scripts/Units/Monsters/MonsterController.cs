using UnityEngine;

namespace TankGameCore
{
    public class MonsterController : MonoBehaviour
    {
        [SerializeField] private UnitKinds kind;
        [SerializeField] private MonsterMovementController movementController;

        public void Initialize()
        {
            movementController.Initialize(kind);
        }
    }
}