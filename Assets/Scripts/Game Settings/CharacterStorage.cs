using UnityEngine;

namespace TankGameCore
{
    [CreateAssetMenu(menuName = "Character Storage", fileName = "Character Storage")]
    public class CharacterStorage : Storage<UnitKinds, CharacterSettings> {}
}