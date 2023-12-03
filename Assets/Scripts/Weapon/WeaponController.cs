using System.Collections;
using System;
using UnityEngine;
using Zenject;

namespace TankGameCore
{
    public class WeaponController : MonoBehaviour
    {
        [Serializable]
        private struct BarrelData
        {
            public Transform barrel;
            public Transform bulletPoint;
        }

        [SerializeField] private WeaponKinds kind;
        [SerializeField] private BarrelData[] barrels;

        [Inject] private WeaponStorage storage;

        private Transform unitTransform;
        private bool isInitialized;
        private WeaponSettings data;
        private bool canFire;
        private int currentBarrelIndex;
        
        public void Initialize(Transform unitGeneral)
        {
            unitTransform = unitGeneral;
            data = storage.GetItem(kind);
            isInitialized = true;
            currentBarrelIndex = 0;
        }

        private void OnEnable() => StartCoroutine(RechargeProcess());
                
        public void Fire()
        {
            if (isInitialized && canFire)
            {
                canFire = false;

                Vector3 position = barrels[currentBarrelIndex].bulletPoint.position;
                Quaternion rotation = unitTransform.rotation;
                Bullet bullet = Instantiate(data.bulletPrefab, position, rotation).GetComponent<Bullet>();
                
                bullet.Activate(data, unitTransform.forward);

                if (barrels.Length > 1)
                {
                    currentBarrelIndex++;
                    if (currentBarrelIndex >= barrels.Length)
                    {
                        currentBarrelIndex = 0;
                    }
                }
            }
        }

        private IEnumerator RechargeProcess()
        {
            yield return new WaitWhile(() => !isInitialized);

            canFire = true;

            while (true)
            {
                if (!canFire)
                {
                    yield return new WaitForSeconds(data.recharge);
                    canFire = true;
                }

                yield return null;
            }
        }
    }
}