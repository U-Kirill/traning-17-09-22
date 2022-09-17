using System;
using Logic.Enemy;
using UnityEngine;

namespace Services.Spell
{
    public class DamageRaySpell : ISpell
    {
        private readonly IInputService _input;
        
        private EnemyHealth _target;
        private float _lastDamage;
        private float _damageTimeout = 0.5f;
        private int _amountPerDamage = 4;
        private PlayerHolder _playerHolder;

        public event Action<ISpell> Ended;

        public DamageRaySpell(IInputService inputService, PlayerHolder playerHolder)
        {
            _playerHolder = playerHolder;
            _input = inputService;
        }
        
        public void Cast(SpellTarget spellTarget)
        {
            _target = spellTarget.GetComponent<EnemyHealth>();
        }

        public void Update()
        {
            if (_target == null || _input.Value != Vector2.zero)
            {
                Ended?.Invoke(this);
                return;
            }
            
            if(CanDamage())
                Damage();
            
            Vector3 direction = _target.transform.position - _playerHolder.Player.position;
            _target.GetComponent<Rigidbody>().velocity = direction.normalized * 2f;
        }

        private bool CanDamage() => Time.time - _lastDamage > _damageTimeout;

        private void Damage()
        {
            _lastDamage = Time.time;
            _target.Damage(_amountPerDamage);
        }
    }
}