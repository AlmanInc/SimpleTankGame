using UnityEngine;

namespace TankGameCore
{
    [CreateAssetMenu(menuName = "WeaponStorage", fileName = "WeaponStorage")]
    public class WeaponStorage : Storage<WeaponKinds, WeaponSettings> {}
}