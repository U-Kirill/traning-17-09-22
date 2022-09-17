using System;
using UnityEngine;

namespace Logic.Enemy
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private int _max = 100;

        public event Action Damaged;
        public event Action Healed;
        
        public int Max => _max;

        public int Current { get; private set; }

        public float HealPercent => Current / (float)Max;

        private void Start()
        {
            MakeFull();
        }

        public void MakeFull()
        {
            Current = Max;
        }

        public void Damage(int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            if (Current == 0)
                return;
            
            int overDamage = Mathf.Max(amount - Current, 0);
            int damage = amount - overDamage;
            Current -= damage;
            Debug.Log($"Damage {Current}");
            Damaged?.Invoke();
        }
        
        public void Heal(int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            if (Current == Max)
                return;

            int maxPossibleHeal = Max - Current;
            int overHeal = Mathf.Max(amount - maxPossibleHeal, 0);
            int heal = amount - overHeal;
            Current += heal;
            Debug.Log($"Heal {Current}");
            Healed?.Invoke();
        }
    }
}