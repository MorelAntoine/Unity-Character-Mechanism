/*
** HumanSystem.cs for Unity-Character-Mechanism
**
** Made by Antoine MOREL
**
** Started on  Jan 09 2019 Antoine MOREL
** Last update Jan 09 2019 Antoine MOREL
** 
** Copyright (c) 2018 - 2019 All Rights Reserved
*/

using CharacterMechanism.Normal.System;
using UnityEngine;

namespace CharacterMechanism.Normal.Example
{
    /// <inheritdoc/>
    /// <summary>
    /// Example of human system
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public sealed class HumanSystem : ACharacterSystem
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////

        ///////////////////////////////
        ////////// Component //////////
        
        private Rigidbody _rigidbody = null;
        
        /////////////////////////////
        ////////// Profile //////////

        [Header("Profile")]
        [SerializeField] private LocomotionProfile _locomotionProfile = null;
        
        //////////////////////////////
        ////////// Property //////////
        //////////////////////////////

        ///////////////////////////////
        ////////// Component //////////
        
        public Rigidbody GetRigidbody => _rigidbody;

        /////////////////////////////
        ////////// Profile //////////

        public LocomotionProfile GetLocomotionProfile => _locomotionProfile;

        ////////////////////////////
        ////////// Method //////////
        ////////////////////////////
        
        protected override void InitializeComponents()
        {
            _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        }

        protected override void LoadComponents()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
    }
}
