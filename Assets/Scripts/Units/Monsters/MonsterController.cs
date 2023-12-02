using UnityEngine;

namespace TankGameCore
{
    public class MonsterController : MonoBehaviour
    {
        [SerializeField] private UnitKinds kind;
        [SerializeField] private MonsterMovementController movementController;

        private void Start()
        {
            movementController.Initialize(kind);
        }
    }
}