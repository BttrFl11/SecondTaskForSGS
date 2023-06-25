using UnityEngine;

namespace Variant3
{
    [RequireComponent(typeof(CharacterController))]
    public class Character : MonoBehaviour
    {
        [SerializeField] private Animator _modelAnimator;
        [SerializeField] private CharacterSettings _settings;

        private CharacterStateController _stateController;
        private CharacterController _characterController;
        private CharacterAnimator _animator;
        private CharacterAim _characterAim;
        private CharacterPhysics _physics;
        private CharacterValues _values;

        public CharacterStateController StateController => _stateController;
        public CharacterController CharacterController => _characterController;
        public CharacterAnimator Animator => _animator;
        public CharacterSettings Settings => _settings;
        public CharacterPhysics Physics => _physics;
        public CharacterValues Values => _values;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();

            Init();
        }

        private void Init()
        {
            _values = new CharacterValues();
            _physics = new CharacterPhysics(this);
            _characterAim = new CharacterAim(this);
            _animator = new CharacterAnimator(_modelAnimator, this);

            _stateController = new CharacterStateController();
            CState_Move move = new(this);
            CState_Jump jump = new(this);
            CState_Fall fall = new(this);

            _stateController.Init(move, jump, fall);
        }

        private void Update()
        {
            _physics.Update(Time.deltaTime);
            _stateController.Update(Time.deltaTime);
            _characterAim.Update();
        }
    }

    public class CharacterValues
    {
        public Vector3 Velocity;
        public Vector3 MoveVelocity;
    }
}
