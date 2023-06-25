using UnityEngine;

namespace Variant3
{
    public class CState_Move : CharacterState
    {
        private readonly Character _character;

        private float _velocityX;
        private float _velocityZ;

        private CharacterMoveSettings Data => _character.Settings.Movement;

        public CState_Move(Character character) : base(character.StateController)
        {
            _character = character;
        }

        private bool TryChangeState()
        {
            if (_character.Physics.IsGrounded() == false)
            {
                Controller.Change<CState_Fall>();
                return true;
            }
            else if (InputProvider.Instance.IsJumping)
            {
                Controller.Change<CState_Jump>();
                return true;
            }

            return false;
        }

        public override void Update(float deltaTime)
        {
            if (TryChangeState())
                return;

            Move();

            SetMoveAnimation();

            TryFire();
        }

        private void TryFire()
        {
            _character.Animator.SetFiring(InputProvider.Instance.IsFiring);

            if (InputProvider.Instance.IsFiring == false)
                return;

            // Shooting //
            // Logic //
        }

        public override void Exit()
        {
            _character.Animator.SetFiring(false);
        }

        private void Move()
        {
            Vector2 input = new Vector2(InputProvider.Instance.GetMoveInputX(), InputProvider.Instance.GetMoveInputY()).normalized;
            _character.Values.MoveVelocity.x = Data.MoveSpeed * input.x;
            _character.Values.MoveVelocity.z = Data.MoveSpeed * input.y;
            _character.Values.MoveVelocity = _character.transform.TransformVector(_character.Values.MoveVelocity);
        }

        private void SetMoveAnimation()
        {
            _velocityX = Vector3.Dot(_character.Values.MoveVelocity, _character.transform.forward);
            _velocityZ = Vector3.Dot(_character.Values.MoveVelocity, _character.transform.right);

            _character.Animator.SetMove(new Vector2(_velocityZ, _velocityX));
            _character.Animator.SetVelocity(_character.Values.MoveVelocity.magnitude);
        }
    }
}