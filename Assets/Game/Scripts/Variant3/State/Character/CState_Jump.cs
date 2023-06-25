using UnityEngine;

namespace Variant3
{
    public class CState_Jump : CharacterState
    {
        private Character _character;

        private CharacterSettings Data => _character.Settings;

        public CState_Jump(Character character) : base(character.StateController)
        {
            _character = character;
        }

        public override void Enter()
        {
            Jump();
        }

        private void SetJumpAnimation()
        {
            _character.Animator.SetJump(true);
        }

        private void Jump()
        {
            _character.Values.Velocity.y = Mathf.Sqrt(Data.Movement.JumpHeight * 2 * -Data.Movement.GravityForce);

            SetJumpAnimation();
        }

        private bool TryChangeState()
        {
            if (_character.Values.Velocity.y <= 0)
            {
                Controller.Change<CState_Fall>();
                return true;
            }

            return false;
        }

        public override void Update(float deltaTime)
        {
            if (TryChangeState())
                return;
        }
    }
}