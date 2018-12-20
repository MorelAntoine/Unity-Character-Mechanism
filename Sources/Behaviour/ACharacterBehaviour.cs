using UniCraft.CharacterMechanism.System;
using UniCraft.CharacterMechanism.System.Motion.Information;
using UnityEngine;

namespace UniCraft.CharacterMechanism.Behaviour
{
    /// <inheritdoc/>
    /// <summary>
    /// Base module to define the behaviour of a character
    /// </summary>
    [DisallowMultipleComponent]
    [RequireComponent(typeof(ACharacterSystem))]
    public abstract class ACharacterBehaviour : MonoBehaviour
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////

        private ACharacterSystem _characterSystem = null;

        ////////////////////////////
        ////////// Method //////////
        ////////////////////////////
        
        //////////////////////////////
        ////////// Callback //////////

        /// <summary>
        /// Initialize the behaviour
        /// </summary>
        protected abstract void Initialize(ACharacterSystem characterSystem, MotionConfiguration motionConfiguration);
        
        /// <summary>
        /// Update the motion input in order to move the character
        /// </summary>
        protected abstract void UpdateMotionInput(MotionInput motionInput);

        ////////////////////////////////////////////
        ////////// MonoBehaviour Callback //////////

        protected virtual void Awake()
        {
            _characterSystem = GetComponent<ACharacterSystem>();
            Initialize(_characterSystem, _characterSystem.GetMotionInformation.GetMotionConfiguration);
        }
        
        protected virtual void Update()
        {
            UpdateMotionInput(_characterSystem.GetMotionInformation.GetMotionInput);
        }
    }
}
