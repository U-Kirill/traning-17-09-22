using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Services.Spell
{
    public class SpellService : ITickable, ISpellService
    {
        private readonly ISpellFactory _spellFactory;
        private readonly List<ISpell> _active = new List<ISpell>();

        public SpellService(ISpellFactory spellFactory)
        {
            _spellFactory = spellFactory;
        }

        public void Cast(SpellTypeId type)
        {
            ISpell spell = _spellFactory.GetSpell(type);;
            spell.Ended += OnSpellEnd;
            _active.Add(spell);
            
            spell.Cast();
        }

        public void Tick()
        {
            foreach (ISpell spell in _active) 
                spell.Update();
        }

        private void OnSpellEnd(ISpell spell) => _active.Remove(spell);
    }
}