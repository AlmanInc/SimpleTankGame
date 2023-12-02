using UnityEngine;
using Zenject;

namespace TankGameCore
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private float distanceOffset;
        [SerializeField] private float heightOffset;

        [Inject] private GameController gameController;

        private Transform cachedTransform;
        private Transform player;
        private Vector3 deltaRotation;
        
        private void Start()
        {
            cachedTransform = transform;
            player = gameController.Player.transform;

            cachedTransform.position = player.position - player.forward * distanceOffset + player.up * heightOffset;
            deltaRotation = cachedTransform.rotation.eulerAngles - player.rotation.eulerAngles;
        }

        private void LateUpdate()
        {
            cachedTransform.rotation = Quaternion.Euler(player.rotation.eulerAngles + deltaRotation);
            cachedTransform.position = player.position - player.forward * distanceOffset + player.up * heightOffset;
        }
    }
}