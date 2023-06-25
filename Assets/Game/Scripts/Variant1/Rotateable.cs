using UnityEngine;

namespace Variant1
{
    public class Rotateable : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Vector3 _direction;

        private Rotator _rotator;

        private void Awake()
        {
            _rotator = new Rotator(transform, _direction, _speed);
        }

        private void Update()
        {
            if (_rotator != null)
                _rotator.Update();
        }
    }
}
