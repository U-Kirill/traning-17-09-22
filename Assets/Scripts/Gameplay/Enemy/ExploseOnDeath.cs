using System;
using UnityEngine;

namespace Logic.Enemy
{
    
    public class ExploseOnDeath : MonoBehaviour
    {
        [SerializeField] private EnemyDeath _death;
        [SerializeField] private Explosion _explosion;

        private void OnEnable()
        {
            _death.Died += _explosion.Explode;
            
        }
        private void OnDisable()
        {
            _death.Died -= _explosion.Explode;
        }
    }
}