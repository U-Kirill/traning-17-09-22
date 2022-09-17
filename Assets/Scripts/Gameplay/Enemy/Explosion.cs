using System.Linq;
using UnityEngine;

namespace Logic.Enemy
{
    public class Explosion : MonoBehaviour
    {
        [SerializeField] private float _radius = 5;
        [SerializeField] private int _explosionForce = 100;
        [SerializeField] private ParticleSystem _particle;

        public void Explode()
        {
            PhysicExplode();
            Instantiate(_particle, transform.position, transform.rotation);
        }

        private void PhysicExplode()
        {
            Collider[] overlapSphere = Physics.OverlapSphere(transform.position, _radius);

            foreach (Rigidbody otherRb in overlapSphere.Select(x => x.attachedRigidbody))
            {
                if (otherRb && otherRb.TryGetComponent(out EnemyHealth enemyHealth))
                {
                    enemyHealth.Damage(enemyHealth.Max / 2);
                    otherRb.AddExplosionForce(_explosionForce, transform.position, _radius);
                }
            }
        }
    }
}