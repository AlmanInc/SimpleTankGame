using System;
using UnityEngine;

namespace TankGameCore
{
    public class WeaponController : MonoBehaviour
    {
        [Serializable]
        private struct BarrelData
        {
            public Transform barrel;    // Move a little when shot
            public Transform bulletPoint;
        }

        [SerializeField] private WeaponKinds kind;
        [SerializeField] private BarrelData[] barrels;
    }
}