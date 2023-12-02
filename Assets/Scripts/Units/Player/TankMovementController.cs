using UnityEngine;
using Zenject;

namespace TankGameCore
{
    public class TankMovementController : MonoBehaviour
    {
        [Inject] private CharacterStorage storage;
        [Inject] private InputController input;

        private Transform cachedTransform;
        private float movementSpeed;
        private float rotationSpeed;

        public void Initialize(UnitKinds kind)
        {
            cachedTransform = transform;

            CharacterSettings data = storage.GetItem(kind);
            movementSpeed = data.movementSpeed;
            rotationSpeed = data.rotationSpeed;

            input.OnMove -= OnMoveAction;
            input.OnMove += OnMoveAction;
        }

        private void OnMoveAction(Vector3 movement)
        {            
            cachedTransform.position += cachedTransform.forward.normalized * movement.z * movementSpeed * Time.deltaTime;
            
            if (movement.x != 0f)
            {
                var rotation = cachedTransform.rotation.eulerAngles;
                rotation.y += movement.x;
                cachedTransform.rotation = Quaternion.Slerp(cachedTransform.rotation, Quaternion.Euler(rotation), Time.deltaTime * rotationSpeed);
            }
        }
    }
}