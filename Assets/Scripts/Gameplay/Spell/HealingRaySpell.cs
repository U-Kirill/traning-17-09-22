using System;
using Logic;
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
        private PlayerHolder _playerHolder;

        public event Action<ISpell> Ended;

        public HealingRaySpell(IInputService inputService, PlayerHolder playerHolder)
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
            if (_input.Value != Vector2.zero)
            {
                Ended?.Invoke(this);
                return;
            }
            
            if(CanHeal())
                Heal();

            Vector3 direction = _playerHolder.Player.position - _target.transform.position;
            _target.GetComponent<Rigidbody>().velocity = direction.normalized * 2f;
        }

        private bool CanHeal() => Time.time - _lastHeal > _healTimeout;

        private void Heal()
        {
            _lastHeal = Time.time;
            _target.Heal(_amountPerHeal);
        }
    }
}