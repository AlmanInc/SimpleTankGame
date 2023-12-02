using UnityEngine;

namespace TankGameCore
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform player;

        private Transform cachedTransform;
        private Vector3 deltaRotation;
        private float distanceOffset;
        private float heightOffset;

        private void Start()
        {
            cachedTransform = transform;
            
            deltaRotation = cachedTransform.rotation.eulerAngles - player.rotation.eulerAngles;

            Vector3 deltaPosition = cachedTransform.position - player.position;
            distanceOffset = deltaPosition.z;
            heightOffset = deltaPosition.y;
        }

        private void LateUpdate()
        {
            cachedTransform.rotation = Quaternion.Euler(player.rotation.eulerAngles + deltaRotation);
            cachedTransform.position = player.position + player.forward * distanceOffset + player.up * heightOffset;
        }
    }
}