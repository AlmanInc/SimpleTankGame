using UnityEngine;
using Zenject;

namespace TankGameCore
{
    public class TankFireController : MonoBehaviour
    {
        [SerializeField] private WeaponController defaultWeapon;
        [SerializeField] private WeaponController[] weapons;

        [Inject] private InputController input;

        private WeaponController currentWeapon;

        public void Initialize()
        {
            foreach (var weapon in weapons)
            {
                weapon.Initialize(transform);
                weapon.gameObject.SetActive(false);
            }

            currentWeapon = defaultWeapon;
            currentWeapon.gameObject.SetActive(true);

            input.OnFire += Fire;
        }

        private void Fire() => currentWeapon.Fire();        
    }
}