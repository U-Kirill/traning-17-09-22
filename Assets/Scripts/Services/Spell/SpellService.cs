using System.Collections.Generic;
using Services.WorldRaycaster;
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

        public void CastFor(SpellTarget spellTarget)
        {
            Debug.Log("cast");
            var type = spellTarget.Type;
            
            ISpell spell = _spellFactory.GetSpell(type);
            spell.Ended += OnSpellEnd;
            _active.Add(spell);
            
            spell.Cast(spellTarget);
        }

        public void Tick()
        {
            foreach (ISpell spell in _active) 
                spell.Update();
        }

        private void OnSpellEnd(ISpell spell) => _active.Remove(spell);
    }
}