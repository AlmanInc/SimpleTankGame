using UnityEngine;
using Zenject;

namespace TankGameCore
{
    public class TankMovementController : MonoBehaviour
    {
        [Inject] private CharacterStorage storage;
        [Inject] private InputController input;

        private CharacterController controller;
        private Rigidbody rb;
        private Transform cachedTransform;
        private float movementSpeed;
        private float rotationSpeed;

        public void Initialize(UnitKinds kind)
        {
            //controller = GetComponent<CharacterController>();
            rb = GetComponent<Rigidbody>();
            cachedTransform = transform;

            CharacterSettings data = storage.GetItem(kind);
            movementSpeed = data.movementSpeed;
            rotationSpeed = data.rotationSpeed;

            input.OnMove -= OnMoveAction;
            input.OnMove += OnMoveAction;
        }

        private void OnMoveAction(Vector3 movement)
        {
            Vector3 motion = cachedTransform.forward * movement.z * movementSpeed * Time.deltaTime;
            //motion += Vector3.down * 0.9f;   // Gravity

            //controller.Move(motion);

            //cachedTransform.position += cachedTransform.forward * movement.z * movementSpeed * Time.deltaTime;

            rb.MovePosition(cachedTransform.position + motion);
            
            if (movement.x != 0f)
            {
                var rotation = cachedTransform.rotation.eulerAngles;
                rotation.y += movement.x;
                cachedTransform.rotation = Quaternion.Slerp(cachedTransform.rotation, Quaternion.Euler(rotation), Time.deltaTime * rotationSpeed);
            }
        }
    }
}