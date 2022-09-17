using System;
using Services.WorldRaycaster;
using UnityEngine;
using Zenject;

namespace Services.Spell
{
    public class SpellCaster : MonoBehaviour
    {
        private ISpellService _spellService;
        private IWorldRaycaster _worldRaycaster;

        [Inject]
        public void Constructor(ISpellService spellService, IWorldRaycaster worldRaycaster)
        {
            _worldRaycaster = worldRaycaster;
            _spellService = spellService;
        }

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                Debug.Log("down");
                SpellTarget target = _worldRaycaster.GetSpellOrNull(SpellTypeId.HealingPedestal);
                if(target != null)
                    _spellService.CastFor(target);
            }
        }
    }
}