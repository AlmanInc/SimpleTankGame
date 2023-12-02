using System.Collections;
using UnityEngine;
using Zenject;

namespace TankGameCore
{
    public class MonsterMovementController : MonoBehaviour
    {
        [Inject] private CharacterStorage storage;
        [Inject] private GameController gameController;

        private bool isInitialized;
        private Transform cachedTransform;
        private Transform player;
        private float movementSpeed;
        private float rotationSpeed;
        private float targetHeight;
        private bool isInInitialZone;

        public void Initialize(UnitKinds kind)
        {
            if (!isInitialized)
            {
                cachedTransform = transform;
                player = gameController.Player.transform;

                CharacterSettings data = storage.GetItem(kind);
                movementSpeed = data.movementSpeed;
                rotationSpeed = data.rotationSpeed;

                isInitialized = true;
            }

            isInInitialZone = true;
            StartCoroutine(MovementProcess());
        }

        private IEnumerator MovementProcess()
        {
            while (isInInitialZone)
            {
                cachedTransform.position += Vector3.up * movementSpeed * Time.deltaTime;
                yield return null;
            }

            while (true)
            {
                Vector3 targetPosition = player.position;
                targetPosition.y = targetHeight;
                cachedTransform.position = Vector3.MoveTowards(cachedTransform.position, targetPosition, movementSpeed * Time.deltaTime);

                Quaternion endRotation = Quaternion.LookRotation(cachedTransform.position - targetPosition);
                cachedTransform.rotation = Quaternion.Slerp(cachedTransform.rotation, endRotation, Time.deltaTime * rotationSpeed);

                yield return null;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            ObjectKindTag target = other.gameObject.GetComponent<ObjectKindTag>();

            if (target != null)
            {
                switch (target.Kind)
                {
                    case ObjectKinds.MostersZone:
                        isInInitialZone = false;
                        targetHeight = cachedTransform.position.y;
                        break;
                }
            }
        }
    }
}