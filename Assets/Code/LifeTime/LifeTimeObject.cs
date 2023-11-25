using UnityEngine;

namespace Code.LifeTime
{
    public class LifeTimeObject : MonoBehaviour
    {
        [SerializeField] private float _lifeTime;

        void Update()
        {
            _lifeTime -= Time.deltaTime;

            if (_lifeTime <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
