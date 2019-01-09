using System;
using UnityEngine;

namespace CharacterMechanism.Normal.Example
{
    /// <summary>
    /// Class containing all the locomotion settings
    /// </summary>
    [Serializable]
    public sealed class LocomotionProfile
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////
        
        [SerializeField, Range(80f, 160f)] private float _angularSpeed = 140f;
        [SerializeField, Range(2f, 8f)] private float _jumpForce = 4f;
        [SerializeField, Range(5f, 20f)] private float _runSpeed = 8f;
        [SerializeField, Range(1f, 4f)] private float _walkSpeed = 2f;
        
        //////////////////////////////
        ////////// Property //////////
        //////////////////////////////

        public float AngularSpeed => _angularSpeed;
        public float JumpForce => _jumpForce;
        public float RunSpeed => _runSpeed;
        public float WalkSpeed => _walkSpeed;
    }
}
