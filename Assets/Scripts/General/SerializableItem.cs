using System;

namespace TankGameCore
{
    [Serializable]
    public struct SerializableItem<TId, TItem>
    {
        public TId id;
        public TItem item;
    }
}