using UnityEngine;

namespace TankGameCore
{
    public class TankController : MonoBehaviour
    {
        [SerializeField] private UnitKinds kind;
        [SerializeField] private TankMovementController movementController;
        [SerializeField] private TankFireController fireController;

        private void Awake()
        {
            movementController.Initialize(kind);
            fireController.Initialize();
        }
    }
}