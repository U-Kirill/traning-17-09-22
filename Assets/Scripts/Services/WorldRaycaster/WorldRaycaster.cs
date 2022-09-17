using Services.Spell;
using UnityEngine;

namespace Services.WorldRaycaster
{
    public class WorldRaycaster
    {
        public Vector3 GetPosition() => 
            Camera.main.ScreenToWorldPoint(Input.mousePosition);

        public SpellTarget GetTrigger()
        {
            Ray screenRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            //Physics.Raycast(screenRay)
        }
    }
}