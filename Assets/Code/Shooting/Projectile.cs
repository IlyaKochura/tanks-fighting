using ObjectPool.Runtime.Contracts;
using UnityEngine;

namespace Code.Shooting
{
    public class Projectile : MonoBehaviour, IRecycle
    {
        public void Shoot(Vector3 shootDir)
        {
            GetComponent<Rigidbody>().AddForce(shootDir * 10, ForceMode.Impulse);
        }

        private void OnCollisionEnter(Collision collision)
        {
            Recycle();
        }

        public void Recycle()
        {
            gameObject.SetActive(false);
        }
    }
}