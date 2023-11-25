using Code.DamageAndHealth.Contracts;
using Code.Shooting.Contracts;
using UnityEngine;

namespace Code.DamageAndHealth
{
    public class DamageDealer : MonoBehaviour
    {
        [SerializeField] private float _damage;
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag("Player") && collision.collider.TryGetComponent(out IDamageable damageable))
            {
                damageable.ApplyDamage(_damage);
            }
        }
    }
}