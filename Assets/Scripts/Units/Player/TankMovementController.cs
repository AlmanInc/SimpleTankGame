using UnityEngine;
using Zenject;

namespace TankGameCore
{
    public class TankMovementController : MonoBehaviour
    {
        [Inject] private CharacterStorage storage;
        [Inject] private InputController input;

        private float movementSpeed;
        private float rotationSpeed;

        public void Initialize(UnitKinds kind)
        {
            CharacterSettings data = storage.GetItem(kind);
            movementSpeed = data.movementSpeed;
            rotationSpeed = data.rotationSpeed;

            input.OnMove -= OnMoveAction;
            input.OnMove += OnMoveAction;
        }

        private void OnMoveAction(Vector3 movement)
        {            
            transform.position += transform.forward.normalized * movement.z * movementSpeed * Time.deltaTime;
            
            if (movement.x != 0f)
            {
                var rotation = transform.rotation.eulerAngles;
                rotation.y += movement.x;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(rotation), Time.deltaTime * rotationSpeed);
            }
        }
    }
}