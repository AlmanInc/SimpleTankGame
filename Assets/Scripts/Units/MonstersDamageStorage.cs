using UnityEngine;

namespace TankGameCore
{
    [CreateAssetMenu(menuName = "MonstersDamageStorage", fileName = "MonstersDamageStorage")]
    public class MonstersDamageStorage : Storage<UnitKinds, float> {}
}