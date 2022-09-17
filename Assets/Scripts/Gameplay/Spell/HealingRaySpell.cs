using System;
using Logic.Enemy;
using UnityEngine;

namespace Services.Spell
{
    public class HealingRaySpell : ISpell
    {
        private readonly IInputService _input;
        
        private EnemyHealth _target;
        private float _lastHeal;
        private float _healTimeout = 1;
        private int _amountPerHeal = 3;

        public event Action<ISpell> Ended;

        public HealingRaySpell(IInputService inputService)
        {
            _input = inputService;
        }
        
        public void Cast(SpellTarget spellTarget)
        {
            _target = spellTarget.GetComponent<EnemyHealth>();
        }

        public void Update()
        {
            if (_input.Value != Vector2.zero)
            {
                Ended?.Invoke(this);
                return;
            }
            
            if(CanHeal())
                Heal();
        }

        private bool CanHeal() => Time.time - _lastHeal > _healTimeout;

        private void Heal()
        {
            _lastHeal = Time.time;
            _target.Heal(_amountPerHeal);
        }
    }
    
    public class DamageRaySpell : ISpell
    {
        private readonly IInputService _input;
        
        private EnemyHealth _target;
        private float _lastDamage;
        private float _damageTimeout = 1;
        private int _amountPerDamage = 3;

        public event Action<ISpell> Ended;

        public DamageRaySpell(IInputService inputService)
        {
            _input = inputService;
        }
        
        public void Cast(SpellTarget spellTarget)
        {
            _target = spellTarget.GetComponent<EnemyHealth>();
        }

        public void Update()
        {
            if (_input.Value != Vector2.zero)
            {
                Ended?.Invoke(this);
                return;
            }
            
            if(CanDamage())
                Damage();
        }

        private bool CanDamage() => Time.time - _lastDamage > _damageTimeout;

        private void Damage()
        {
            _lastDamage = Time.time;
            _target.Damage(_amountPerDamage);
        }
    }
}