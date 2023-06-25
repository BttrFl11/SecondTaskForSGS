using UnityEngine;

namespace Variant3
{
    public class CharacterAnimator
    {
        #region Unit Animator Parameters Names

        private const string MOVE_X = "MoveX";
        private const string MOVE_Y = "MoveY";
        private const string JUMPRING = "isJumping";
        private const string FIRING = "isFiring";
        private const string VELOCITY = "Velocity";

        #endregion

        private readonly Animator _animator;
        private readonly Character _character;

        private CharacterAnimationSettings Data => _character.Settings.Animation;

        public CharacterAnimator(Animator animator, Character character)
        {
            _animator = animator;
            _character = character;
        }

        private void SetFloat(string parameterName, float value)
        {
            float dampTime = Mathf.Lerp(Data.MinDampTime, Data.MaxDampTime, _character.Values.MoveVelocity.magnitude / 1);
            _animator.SetFloat(parameterName, value, dampTime, Time.deltaTime);
        }

        private void SetBool(string parameterName, bool value)
        {
            _animator.SetBool(parameterName, value);
        }

        public void SetVelocity(float value)
        {
            SetFloat(VELOCITY, value);
        }

        public void SetFiring(bool value)
        {
            SetBool(FIRING, value);
        }

        public void SetMove(Vector2 move)
        {
            SetFloat(MOVE_X, move.x);
            SetFloat(MOVE_Y, move.y);
        }

        public void SetJump(bool value)
        {
            SetBool(JUMPRING, value);
        }
    }
}