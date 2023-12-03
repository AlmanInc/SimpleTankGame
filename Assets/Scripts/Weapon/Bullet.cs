using System.Collections;
using UnityEngine;

namespace TankGameCore
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;

        public void Activate(WeaponSettings data, Vector3 direction) => StartCoroutine(BulletProcess(data, direction));
        
        private IEnumerator BulletProcess(WeaponSettings data, Vector3 direction)
        {
            transform.rotation = Quaternion.Euler(direction);
            rb.velocity = direction.normalized * data.bulletSpeed;

            float time = data.bulletLifetime;

            while (time >= 0f)
            {
                yield return null;
                time -= Time.deltaTime;
            }

            Destroy(this.gameObject);
        }
    }
}