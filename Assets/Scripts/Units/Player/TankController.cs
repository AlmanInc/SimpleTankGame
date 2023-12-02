using UnityEngine;

namespace TankGameCore
{
    public class TankController : MonoBehaviour
    {
        [SerializeField] private UnitKinds kind;
        [SerializeField] private TankMovementController movementController;

        private void Awake()
        {
            movementController.Initialize(kind);
        }
    }
}