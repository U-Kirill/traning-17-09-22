using System.Collections.Generic;
using System.Linq;
using Services.Spell;
using UnityEngine;

namespace Services.WorldRaycaster
{
    public class WorldRaycaster : IWorldRaycaster
    {
        public SpellTarget GetSpellOrNull(SpellTypeId type)
        {
            Ray screenRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(screenRay, out RaycastHit hit))
            {
                List<SpellTarget> spellTargets = hit.collider.GetComponents<SpellTarget>().ToList();
                spellTargets.ForEach(x => x.LastTouch = hit.point);

                return spellTargets.FirstOrDefault(x => x.Type == type);
            }

            return null;
        }
    }
}