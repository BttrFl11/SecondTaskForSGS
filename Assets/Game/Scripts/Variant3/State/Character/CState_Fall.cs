using UnityEngine;

namespace Variant3
{
    public class CState_Fall : CharacterState
    {
        private Character _character;

        public CState_Fall(Character character) : base(character.StateController)
        {
            _character = character;
        }

        private bool TryChangeState()
        {
            if (_character.Physics.IsGrounded())
            {
                Controller.Change<CState_Move>();
                return true;
            }

            return false;
        }

        public override void Update(float deltaTime)
        {
            if (TryChangeState())
                return;
        }

        private void OffJumpAnimation()
        {
            _character.Animator.SetJump(false);
        }

        public override void Exit()
        {
            OffJumpAnimation();
        }
    }
}