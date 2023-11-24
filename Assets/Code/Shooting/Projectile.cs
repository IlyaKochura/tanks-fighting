using ObjectPool.Runtime.Contracts;
using UnityEngine;

namespace Code.Shooting
{
    public class Projectile : MonoBehaviour, IRecycle
    {
        private void Update()
        {
            transform.Translate(Vector3.forward * 50f * Time.deltaTime);
        }

        public void Recycle()
        {
            gameObject.SetActive(false);
        }
    }
}