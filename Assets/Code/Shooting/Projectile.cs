using Code.DamageAndHealth.Contracts;
using ObjectPool.Runtime.Contracts;
using UnityEngine;

namespace Code.Shooting
{
    public class Projectile : MonoBehaviour, IRecycle
    {
        private Rigidbody _rigidbody;
        private int _damage;
        private int _speed;

        public void Shoot(Vector3 shootDir)
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.AddForce(shootDir * _speed, ForceMode.Impulse);
        }

        public void Setup(int damage, int speed)
        {
            _damage = damage;
            _speed = speed;
        }

        private void OnCollisionEnter(Collision collision)
        {
            Recycle();

            if (collision.collider.TryGetComponent(out IDamageable damageable))
            {
                damageable.ApplyDamage(_damage);
            }
        }

        public void Recycle()
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
            gameObject.SetActive(false);
        }
    }
}