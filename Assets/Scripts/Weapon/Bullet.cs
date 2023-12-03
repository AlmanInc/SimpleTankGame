using System.Collections;
using UnityEngine;

namespace TankGameCore
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;

        private WeaponSettings currentData;

        public void Activate(WeaponSettings data, Vector3 direction)
        {
            currentData = data;
            StartCoroutine(BulletProcess(direction));
        }
        
        private IEnumerator BulletProcess(Vector3 direction)
        {
            transform.rotation = Quaternion.Euler(direction);

            Vector3 velocity = direction.normalized * currentData.bulletSpeed;
            rb.velocity = velocity;

            float time = currentData.bulletLifetime;

            while (time >= 0f)
            {
                yield return new WaitForFixedUpdate();
                time -= Time.fixedDeltaTime;

                rb.velocity = velocity;
            }

            Destroy(this.gameObject);
        }

        private void OnCollisionEnter(Collision collision)
        {
            MonsterController monster = collision.gameObject.GetComponent<MonsterController>();
            if (monster != null)
            {
                monster.ApplyDamage(currentData.damage);
                Destroy(this.gameObject);
            }
        }
    }
}