namespace Services.Spell
{
    public interface ISpellFactory
    {
        ISpell GetSpell(SpellTypeId type);
    }
}