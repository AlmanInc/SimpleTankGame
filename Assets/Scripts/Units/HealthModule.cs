using System;
using UnityEngine.UI;
using UnityEngine;
using Zenject;

namespace TankGameCore
{
    public class HealthModule : MonoBehaviour
    {
        public event Action OnDie;

        [SerializeField] private Image lifeBar;

        [Inject] private CharacterStorage storage;

        private float startHealth;
        private float health;
        private float defense;

        public void Initialize(UnitKinds kind)
        {
            CharacterSettings data = storage.GetItem(kind);

            startHealth = data.health;
            health = data.health;
            defense = data.defense;

            lifeBar.fillAmount = 1f;
        }

        public void ApplyDamage(float damage)
        {
            health = Mathf.Clamp(health - damage * defense, 0f, health);
            lifeBar.fillAmount = Mathf.Clamp01(health / startHealth);
                        
            if (health <= 0f)
                OnDie?.Invoke();
        }
    }
}