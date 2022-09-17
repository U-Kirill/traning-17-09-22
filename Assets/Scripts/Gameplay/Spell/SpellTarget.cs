using System.Collections.Generic;
using UnityEngine;

namespace Services.Spell
{
    public class SpellTarget : MonoBehaviour
    {
        [SerializeField] private SpellTypeId[] _spell;

        public IReadOnlyList<SpellTypeId> Spell => _spell;
    }
}