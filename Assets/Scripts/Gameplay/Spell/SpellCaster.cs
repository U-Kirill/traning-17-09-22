using System;
using UnityEngine;
using Zenject;

namespace Services.Spell
{
    public class SpellCaster : MonoBehaviour
    {
        private ISpellService _spellService;

        [Inject]
        public void Constructor(ISpellService spellService)
        {
            _spellService = spellService;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                _spellService.Cast(SpellTypeId.HealingPedestal);
            }
        }
    }
}