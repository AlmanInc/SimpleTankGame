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
            input.OnChooseWeaponLeft += ChooseNextLeftWeapon;
            input.OnChooseWeaponRight += ChooseNextRightWeapon;
        }
              
        private void Fire() => currentWeapon.Fire();

        private void ChooseNextLeftWeapon()
        {
            int index = GetCurrentWeaponIndex();
            index++;

            if (index >= weapons.Length)
                index = 0;

            ChangeWeapon(index);
        }

        private void ChooseNextRightWeapon()
        {
            int index = GetCurrentWeaponIndex();
            index--;

            if (index < 0)
                index = weapons.Length - 1;

            ChangeWeapon(index);
        }

        private int GetCurrentWeaponIndex()
        {
            for (int i = 0; i < weapons.Length; i++)
            {
                if (currentWeapon == weapons[i])
                    return i;
            }

            return 0;
        }

        private void ChangeWeapon(int index)
        {
            currentWeapon.gameObject.SetActive(false);
            currentWeapon = weapons[index];
            currentWeapon.gameObject.SetActive(true);
        }
    }
}