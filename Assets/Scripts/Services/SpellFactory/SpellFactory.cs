using System;
using System.Collections.Generic;
using Zenject;

namespace Services.Spell
{
    class SpellFactory : ISpellFactory
    {
        private readonly Dictionary<SpellTypeId, Func<ISpell>> _spells;

        public SpellFactory(IInstantiator instantiator)
        {
            _spells = new Dictionary<SpellTypeId, Func<ISpell>>
            {
                [SpellTypeId.HealingPedestal] = instantiator.Instantiate<HealingPedestalSpell>
            };
        }

        public ISpell GetSpell(SpellTypeId type) => _spells[type]();
    }
}