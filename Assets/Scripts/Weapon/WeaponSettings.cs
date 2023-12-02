using System;
using UnityEngine;

namespace TankGameCore
{    
    [Serializable]
    public struct WeaponSettings
    {
        public float damage;
        public float recharge;
        public GameObject bulletPrefab;
        public float bulletSpeed;
        public float bulletLifetime;
    }
}