using System;
using UnityEngine;

namespace Logic.Enemy
{
    public class TouchExplode : MonoBehaviour
    {
        [SerializeField] private Explosion _explosion;

        private bool _isAlreadyExplodeInThisPair = false;
        
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out TouchExplode otherExplode))
            {
                _isAlreadyExplodeInThisPair = true;
                otherExplode.TryExplode();
            }
        }

        private void Update()
        {
            _isAlreadyExplodeInThisPair = false;
        }

        public void TryExplode()
        {
            if(_isAlreadyExplodeInThisPair)
                return;
            
            _explosion.Explode();
        }
    }
}