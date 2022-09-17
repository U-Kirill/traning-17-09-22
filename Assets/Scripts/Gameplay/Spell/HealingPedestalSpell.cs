using System;
using UnityEngine;

namespace Services.Spell
{
    public class HealingPedestalSpell : ISpell
    {
        private readonly IGameFactory _gameFactory;

        public HealingPedestalSpell(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        public event Action<ISpell> Ended;
        
        public void Cast(SpellTarget spellTarget)
        {
            _gameFactory.CreateHealingPedestal(spellTarget.LastTouch);
            Ended?.Invoke(this);
        }

        public void Update()
        {
            Debug.Log("Update");
        }
    }
}