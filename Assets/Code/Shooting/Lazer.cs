using ObjectPool.Runtime.Contracts;
using UnityEngine;

namespace Code.Shooting
{
    public class Lazer : MonoBehaviour, IRecycle
    {
        [SerializeField] private LineRenderer _lineRenderer;

        public void SetupPoint(int index, Vector3 point)
        {
            _lineRenderer.SetPosition(index, point);
        }

        public void Recycle()
        {
            gameObject.SetActive(false);
        }
    }
}