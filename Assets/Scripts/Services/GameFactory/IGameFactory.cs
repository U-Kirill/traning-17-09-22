using UnityEngine;

namespace Services.Spell
{
    public interface IGameFactory
    {
        GameObject CreateHealingPedestal(Vector3 position);
    }
}