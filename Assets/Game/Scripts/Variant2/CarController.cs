using UnityEngine;

namespace Variant2
{
    public class CarController : MonoBehaviour
    {
        [Header("Wheel Colliders")]
        [SerializeField] private WheelCollider _frontLeft;
        [SerializeField] private WheelCollider _frontRight;
        [SerializeField] private WheelCollider _backLeft;
        [SerializeField] private WheelCollider _backRight;

        [Header("Wheel Meshes")]
        [SerializeField] private Transform _frontLeftMesh;
        [SerializeField] private Transform _frontRightMesh;
        [SerializeField] private Transform _backLeftMesh;
        [SerializeField] private Transform _backRightMesh;

        [Header("Settings")]
        [SerializeField] private float _maxAcceleration;
        [SerializeField] private float _maxTurnAngle;
        [SerializeField] private float _turnSensitivity;
        [SerializeField] private float _accelerationSensitivity;

        private float _lastTurnDirection;
        private InputProvider _inputProvider;

        private float _currentAcceleration;
        private float CurrentAcceleration
        {
            get => _currentAcceleration;
            set
            {
                _currentAcceleration = value;
                if (_currentAcceleration > _maxAcceleration)
                    _currentAcceleration = _maxAcceleration;
                else if (_currentAcceleration < -_maxAcceleration)
                    _currentAcceleration = -_maxAcceleration;
            }
        }
        private float _currentTurnAngle;
        private float CurrentTurnAngle
        {
            get => _currentTurnAngle;
            set
            {
                _currentTurnAngle = value;
                if (_currentTurnAngle > _maxTurnAngle)
                    _currentTurnAngle = _maxTurnAngle;
                else if (_currentTurnAngle < -_maxTurnAngle)
                    _currentTurnAngle = -_maxTurnAngle;
            }
        }

        private void Awake()
        {
            _inputProvider = FindObjectOfType<InputProvider>();
        }

        private void Update()
        {
            ReadHorizontalInput();
            ReadVerticalInput();

            _frontLeft.motorTorque = CurrentAcceleration;
            _frontRight.motorTorque = CurrentAcceleration;

            _frontLeft.steerAngle = CurrentTurnAngle;
            _frontRight.steerAngle = CurrentTurnAngle;

            UpdateWheel(_frontLeft, _frontLeftMesh);
            UpdateWheel(_frontRight, _frontRightMesh);
            UpdateWheel(_backLeft, _backLeftMesh);
            UpdateWheel(_backRight, _backRightMesh);
        }

        private void ReadVerticalInput()
        {
            if (_inputProvider.VerticalInput != 0)
                CurrentAcceleration += _accelerationSensitivity * _inputProvider.VerticalInput * Time.deltaTime;
            else
                CurrentAcceleration = 0;
        }

        private void ReadHorizontalInput()
        {
            if (_inputProvider.HorizontalInput != 0)
            {
                CurrentTurnAngle += _turnSensitivity * _inputProvider.HorizontalInput * Time.deltaTime;
                _lastTurnDirection = _inputProvider.HorizontalInput;
            }
            else
            {
                if (_lastTurnDirection > 0)
                {
                    CurrentTurnAngle -= _turnSensitivity * Time.deltaTime;
                    if(CurrentTurnAngle < 0)
                        CurrentTurnAngle = 0;
                }
                else
                {
                    CurrentTurnAngle += _turnSensitivity * Time.deltaTime;
                    if (CurrentTurnAngle > 0)
                        CurrentTurnAngle = 0;
                }
            }

        }

        private void UpdateWheel(WheelCollider wheel, Transform wheelMesh)
        {
            wheel.GetWorldPose(out Vector3 position, out Quaternion rotation);
            wheelMesh.position = position;
            wheelMesh.rotation = rotation;
        }
    }
}