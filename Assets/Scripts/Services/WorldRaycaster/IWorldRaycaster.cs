using Services.Spell;

namespace Services.WorldRaycaster
{
    public interface IWorldRaycaster
    {
        SpellTarget GetSpellOrNull(SpellTypeId type);
    }
}