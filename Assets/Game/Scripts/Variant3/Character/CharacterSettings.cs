using System;
using UnityEngine;

namespace Variant3
{
    [Serializable]
    public class CharacterSettings
    {
        [SerializeField] private CharacterMoveSettings _movement;
        [SerializeField] private CharacterAimSettings _aim;
        [SerializeField] private CharacterAnimationSettings _animation;

        public CharacterMoveSettings Movement => _movement;
        public CharacterAimSettings Aim => _aim;
        public CharacterAnimationSettings Animation => _animation;
    }

    [Serializable]
    public class CharacterAnimationSettings
    {
        [SerializeField] private float _maxDampTime;
        [SerializeField] private float _minDampTime;

        public float MaxDampTime => _maxDampTime;
        public float MinDampTime => _minDampTime;
    }

    [Serializable]
    public class CharacterAimSettings
    {
        [SerializeField] private float _lookSensitivity;

        public float LookSensitivity => _lookSensitivity;
    }

    [Serializable]
    public class CharacterMoveSettings
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _jumpHeight;
        [SerializeField] private float _gravityForce;
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private float _groundCheckRadius;

        public float MoveSpeed => _moveSpeed;
        public float JumpHeight => _jumpHeight;
        public float GravityForce => _gravityForce;
        public LayerMask GroundLayer => _groundLayer;
        public float GroundCheckRadius => _groundCheckRadius;
    }
}