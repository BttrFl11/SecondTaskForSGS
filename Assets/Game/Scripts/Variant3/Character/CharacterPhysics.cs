using UnityEngine;

namespace Variant3
{
    public class CharacterPhysics
    {
        private Character _character;

        private Transform Transform => _character.transform;
        public CharacterSettings Data => _character.Settings;
        public CharacterController Controller => _character.CharacterController;
        public CharacterValues Values => _character.Values;

        public CharacterPhysics(Character character)
        {
            _character = character;
        }

        public void Update(float deltaTime)
        {
            ApplyVelocity(deltaTime);
        }

        public void ApplyVelocity(float deltaTime)
        {
            if (Controller.isGrounded == false)
            {
                Values.Velocity.y += Data.Movement.GravityForce * deltaTime;
            }

            Controller.Move(Values.Velocity * deltaTime);
            Controller.Move(Values.MoveVelocity * deltaTime);
        }

        public bool IsGrounded()
        {
            return Physics.CheckSphere(_character.transform.position, Data.Movement.GroundCheckRadius, Data.Movement.GroundLayer);
        }
    }
}
