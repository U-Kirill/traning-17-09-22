using System;
using UnityEngine;

namespace Logic.Enemy
{
    public class LookAtCamera : MonoBehaviour
    {
        private void Update()
        {
            transform.LookAt(Camera.main.transform);
            Vector3 eulerAngles = transform.eulerAngles;
            eulerAngles.y = 0;
             transform.eulerAngles = eulerAngles;
            
        }
    }
}