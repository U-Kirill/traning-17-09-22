using System;

namespace Services.Spell
{
    public interface ISpell
    {
        event Action<ISpell> Ended;
        void Cast(SpellTarget spellTarget);
        void Update();
    }
}