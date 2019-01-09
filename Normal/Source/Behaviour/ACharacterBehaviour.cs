using CharacterMechanism.Normal.Information;
using CharacterMechanism.Normal.System;
using UnityEngine;

namespace CharacterMechanism.Normal.Behaviour
{
    /// <inheritdoc />
    /// <summary>
    /// Base class to create a generic character behaviour
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
        
        ////////// Activation //////////

        protected abstract void OnDestroy();

        protected abstract void OnDisable();
        
        protected abstract void OnEnable();
        
        ////////// Information //////////

        /// <summary>
        /// Initialize all the information used to drive the action
        /// </summary>
        /// <remarks>
        /// Call at the beginning after LoadInformationComponents
        /// </remarks>
        protected abstract void InitializeInformation();

        /// <summary>
        /// Load all the components use as information
        /// </summary>
        /// <remarks>
        /// Call at beginning before InitializeInformation
        /// </remarks>
        protected abstract void LoadInformationComponents();
        
        /// <summary>
        /// Override the reset method of the input information
        /// </summary>
        /// <remarks>
        /// Note that InputInformation.Reset still happen before. Call every Update before UpdateInputInformation
        /// </remarks>
        protected abstract void OverrideInputInformationReset(InputInformation inputInformation);
        
        /// <summary>
        /// Update the required input information used to drive the action
        /// </summary>
        /// <remarks>
        /// Call every Update after OverrideInputInformationReset
        /// </remarks>
        protected abstract void UpdateInputInformation(InputInformation inputInformation);
        
        ////////////////////////////////////////////
        ////////// MonoBehaviour Callback //////////
        
        protected virtual void Awake()
        {
            _characterSystem = GetComponent<ACharacterSystem>();
            LoadInformationComponents();
            InitializeInformation();
        }

        protected virtual void Update()
        {
            _characterSystem.InputInformation.Reset();
            OverrideInputInformationReset(_characterSystem.InputInformation);
            UpdateInputInformation(_characterSystem.InputInformation);
        }
    }
}
