using System;
using UnityEngine;

namespace Logic.Enemy
{
    public class EnemyDeath : MonoBehaviour
    {
        [SerializeField] private EnemyHealth _health;

        private bool _died;
        
        public event Action Died;

        private void OnEnable()
        {
            _health.Damaged += OnDamaged;
        }
        
        private void OnDisable()
        {
            _health.Damaged -= OnDamaged;
        }

        private void OnDamaged()
        {
            if(_died)
                throw new InvalidOperationException();

            if (_health.Current == 0)
                Die();
        }

        private void Die()
        {
            _died = true;
            Died?.Invoke();
            Destroy(gameObject);
        }
    }
}