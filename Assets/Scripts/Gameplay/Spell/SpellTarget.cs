using System.Collections.Generic;
using UnityEngine;

namespace Services.Spell
{
    public class SpellTarget : MonoBehaviour
    {
        [SerializeField] private SpellTypeId _type;

        public SpellTypeId Type => _type;
    }
}