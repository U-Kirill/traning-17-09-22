using System.Linq;
using Services.Spell;
using UnityEngine;

namespace Services.WorldRaycaster
{
    public interface IWorldRaycaster
    {
        SpellTarget GetSpellOrNull(SpellTypeId type);
    }

    public class WorldRaycaster : IWorldRaycaster
    {
        public SpellTarget GetSpellOrNull(SpellTypeId type)
        {
            Ray screenRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(screenRay, out RaycastHit hit))
            {
                Debug.Log("hit");
                if (hit.collider.TryGetComponent(out SpellTarget spellTarget))
                {
                    Debug.Log("has component");
                    return spellTarget.Type == type ? spellTarget : null;
                }
            }

            return null;
        }
    }
}