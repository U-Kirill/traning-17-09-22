using UnityEngine;
using Zenject;

namespace Services
{
    public class InputService : ITickable, IInputService
    {
        public Vector2 Value { get; private set; }

        public void Tick()
        {
            Vector2 input = Vector2.zero;
        
            if(Input.GetKey(KeyCode.A))
                input += Vector2.left;
            if(Input.GetKey(KeyCode.D))
                input += Vector2.right;
            if(Input.GetKey(KeyCode.W))
                input += Vector2.up;
            if(Input.GetKey(KeyCode.S))
                input += Vector2.down;

            Value = input;
        }
    }
}