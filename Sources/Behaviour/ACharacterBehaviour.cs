using UniCraft.CharacterMechanism.System;
using UniCraft.CharacterMechanism.System.Motion;
using UnityEngine;

namespace UniCraft.CharacterMechanism.Behaviour
{
    /// <inheritdoc/>
    /// <summary>
    /// Base Module to create character behaviour
    /// </summary>
    [DisallowMultipleComponent]
    [RequireComponent(typeof(ACharacterSystem))]
    public abstract class ACharacterBehaviour : MonoBehaviour
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////

        protected ACharacterSystem CharacterSystem = null;

        ////////////////////////////
        ////////// Method //////////
        ////////////////////////////
        
        //////////////////////////////
        ////////// Callback //////////

        /// <summary>
        /// Initialize the behaviour
        /// </summary>
        protected abstract void Initialize(MotionInput mi);
        
        /// <summary>
        /// Update the motion input in order to manipulate the character
        /// </summary>
        protected abstract void UpdateMotionInput(MotionInput mi);

        ////////////////////////////////////////////
        ////////// MonoBehaviour Callback //////////

        protected virtual void Awake()
        {
            CharacterSystem = GetComponent<ACharacterSystem>();
            Initialize(CharacterSystem.GetMotionInput);
        }
        
        protected virtual void Update()
        {
            UpdateMotionInput(CharacterSystem.GetMotionInput);
        }
    }
}
