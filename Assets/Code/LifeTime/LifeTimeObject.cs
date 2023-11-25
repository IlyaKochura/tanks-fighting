using ObjectPool.Runtime.Contracts;
using UnityEngine;

namespace Code.LifeTime
{
    public class LifeTimeObject : MonoBehaviour
    {
        [SerializeField] private float _lifeTime;

        private float _cachedLifeTime;

        private void OnEnable()
        {
            _cachedLifeTime = _lifeTime;
        }

        private void OnDisable()
        {
            _cachedLifeTime = _lifeTime;
        }

        void Update()
        {
            _cachedLifeTime -= Time.deltaTime;

            if (_cachedLifeTime <= 0)
            {
                if (TryGetComponent(out IRecycle recycle))
                {
                    recycle.Recycle();
                    return;
                }
                
                Destroy(gameObject);
            }
        }
    }
}
