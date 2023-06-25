using UnityEngine;

namespace Variant1
{
    public class Rotator
    {
        private Transform _transform;
        private Vector3 _direction;
        private float _speed;

        public Rotator(Transform transform, Vector3 direction, float speed)
        {
            _transform = transform;
            _direction = direction;
            _speed = speed;
        }

        public void Update()
        {
            _transform.Rotate(_speed * Time.deltaTime * _direction, Space.Self);
        }
    }
}
