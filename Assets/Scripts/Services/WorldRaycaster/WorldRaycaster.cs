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
                if (hit.collider.TryGetComponent(out SpellTarget spellTarget))
                {
                    Debug.Log($"set {hit.point}");
                    spellTarget.LastTouch = hit.point;
                    return spellTarget.Type == type ? spellTarget : null;
                }
            }

            return null;
        }
    }
}