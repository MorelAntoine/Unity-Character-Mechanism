using UnityEngine;

namespace CharacterMechanism.Light
{
    /// <inheritdoc/>
    /// <summary>
    /// Base class to create a generic light character mechanism
    /// </summary>
    [DisallowMultipleComponent]
    public abstract class ALightCharacterMechanism : MonoBehaviour
    {
        ////////////////////////////
        ////////// Method //////////
        ////////////////////////////
        
        //////////////////////////////
        ////////// Callback //////////
        
        ////////// Action //////////

        /// <summary>
        /// Launch the action
        /// </summary>
        /// <remarks>
        /// Call at the beginning
        /// </remarks>
        protected abstract void BeginAction();

        /// <summary>
        /// Update the action
        /// </summary>
        /// <remarks>
        /// Call every FixedUpdate
        /// </remarks>
        protected abstract void UpdateAction();
        
        ////////// Activation //////////

        protected abstract void OnDestroy();

        protected abstract void OnDisable();

        protected abstract void OnEnable();
        
        ////////// Component //////////

        /// <summary>
        /// Initialize all the loaded components
        /// </summary>
        /// <remarks>
        /// Call at the beginning after LoadComponents
        /// </remarks>
        protected abstract void InitializeComponents();

        /// <summary>
        /// Load all the required components
        /// </summary>
        /// <remarks>
        /// Call at the beginning before InitializeComponents
        /// </remarks>
        protected abstract void LoadComponents();

        ////////// Input Information //////////

        /// <summary>
        /// Reset all the input information to there default value
        /// </summary>
        /// <remarks>
        /// Call every Update before UpdateInputInformation
        /// </remarks>
        protected abstract void ResetInputInformation();

        /// <summary>
        /// Update the input information used to drive the action
        /// </summary>
        /// <remarks>
        /// Call every Update after ResetInputInformation
        /// </remarks>
        protected abstract void UpdateInputInformation();

        ////////////////////////////////////////////
        ////////// MonoBehaviour Callback //////////

        protected virtual void Awake()
        {
            LoadComponents();
            InitializeComponents();
        }

        protected virtual void FixedUpdate()
        {
            UpdateAction();
        }

        protected virtual void Start()
        {
            BeginAction();
        }

        protected virtual void Update()
        {
            ResetInputInformation();
            UpdateInputInformation();
        }
    }
}
