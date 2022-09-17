using UnityEngine;

namespace Services.Spell
{
    public class GameFactory : IGameFactory
    {
        public GameObject CreateHealingPedestal(Vector3 position)
        {
            return GameObject.CreatePrimitive(PrimitiveType.Cube);
        }
    }
}