using UnityEngine;

namespace TankGameCore
{
    public class ObjectKindTag : MonoBehaviour
    {
        [SerializeField] private ObjectKinds kind;

        public ObjectKinds Kind => kind;
    }
}