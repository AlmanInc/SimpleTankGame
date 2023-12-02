using System;

namespace TankGameCore
{
    [Serializable]
    public struct CharacterSettings
    {
        public float health;
        public float defense;
        public float movementSpeed;
        public float rotationSpeed;
    }
}