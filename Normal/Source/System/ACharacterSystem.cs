using CharacterMechanism.Normal.Attribute;
using CharacterMechanism.Normal.Information;
using CharacterMechanism.Normal.ScriptableObject;
using UnityEngine;

namespace CharacterMechanism.Normal.System
{
    /// <inheritdoc />
    /// <summary>
    /// Base class to create a character system
    /// </summary>
    [DisallowMultipleComponent]
    public abstract class ACharacterSystem : MonoBehaviour
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////
        
        ////////////////////////////////////////////////
        ////////// Action State Configuration //////////
        
        [SerializeField] private AActionState _startActionState = null;
        
        //////////////////////////////////////////////
        ////////// Action State Information //////////
        
        [ReadOnly, SerializeField] private AActionState _currentActionState = null;
        [ReadOnly, SerializeField] private AActionState _previousActionState = null;
        
        ///////////////////////////////////
        ////////// Debug Setting //////////
        
        [SerializeField] private bool _shouldDisplayTransition = false;
        
        ///////////////////////////////////////
        ////////// Input Information //////////
        
        [SerializeField] private InputInformation _inputInformation = null;
        
        ///////////////////////////////////////////
        ////////// Trigger Configuration //////////

        [SerializeField] private ActionTransition[] _triggerActionTransitions = null;
        
        //////////////////////////////
        ////////// Property //////////
        //////////////////////////////

        //////////////////////////////////////////////
        ////////// Action State Information //////////
        
        public AActionState GetCurrentActionState => _currentActionState;
        public AActionState GetPreviousActionState => _previousActionState;
        
        ///////////////////////////////////
        ////////// Debug Setting //////////

        public bool ShouldDisplayTransition
        {
            get { return _shouldDisplayTransition; }
            set { _shouldDisplayTransition = value; }
        }
        
        ///////////////////////////////////////
        ////////// Input Information //////////

        /// <summary>
        /// Return the input information of the system to control the action
        /// </summary>
        public InputInformation InputInformation => _inputInformation;

        ////////////////////////////
        ////////// Method //////////
        ////////////////////////////
        
        //////////////////////////////
        ////////// Callback //////////
        
        /// <summary>
        /// Initialize all the loaded components to drive the action
        /// </summary>
        /// <remarks>
        /// Call at the beginning after LoadComponents
        /// </remarks>
        protected abstract void InitializeComponents();
        
        /// <summary>
        /// Load all the components to drive the action
        /// </summary>
        /// <remarks>
        /// Call at the beginning before InitializeComponents
        /// </remarks>
        protected abstract void LoadComponents();
        
        ////////////////////////////////////////////
        ////////// MonoBehaviour Callback //////////
        
        protected virtual void Awake()
        {
            AttemptToLoadStartActionState();
            LoadComponents();
            InitializeComponents();
        }
        
        protected virtual void FixedUpdate()
        {
            _currentActionState.UpdateAction(this, _inputInformation);
        }

        protected virtual void Start()
        {
            _currentActionState.BeginAction(this, _inputInformation);
        }

        protected virtual void Update()
        {
            if ( !AttemptToTriggerActionTransition() )
            {
                AttemptToTransitToNextActionState();
            }
        }
        
        /////////////////////////////
        ////////// Service //////////
        
        /// <summary>
        /// Attempt to load the start action state
        /// </summary>
        /// <remarks>
        /// First function to be called at the beginning
        /// </remarks>
        private void AttemptToLoadStartActionState()
        {
            _currentActionState = _startActionState;
            if ( !_currentActionState )
            {
                Debug.LogError("There is no start action state!", gameObject);
                enabled = false;
            }
        }

        /// <summary>
        /// Attempt to transit to a next action state using the associated action transitions 
        /// </summary>
        /// <remarks>
        /// Call every Update if AttemptToTriggerActionTransition is false
        /// </remarks>
        private void AttemptToTransitToNextActionState()
        {
            var nextActionState = _currentActionState.AttemptToGetNextActionState(_inputInformation);

            if ( nextActionState )
            {
                TransitToNextActionState(nextActionState);
            }
        }

        /// <summary>
        /// Attempt to trigger one of the trigger action transition and transit to her action state
        /// </summary>
        /// <remarks>
        /// Call every Update ; if true AttemptToTransitToNextActionState is not called
        /// </remarks>
        private bool AttemptToTriggerActionTransition()
        {
            foreach ( var triggerActionTransition in _triggerActionTransitions )
            {
                var nextActionState = triggerActionTransition.Simulate(_inputInformation);
                
                if ( nextActionState )
                {
                    TransitToNextActionState(nextActionState);
                    return (true);
                }
            }
            return (false);
        }

        /// <summary>
        /// Transit to the next action state
        /// </summary>
        private void TransitToNextActionState(AActionState nextActionState)
        {
            _currentActionState.EndAction(this, _inputInformation);
            _previousActionState = _currentActionState;
            _currentActionState = nextActionState;
            _currentActionState.BeginAction(this, _inputInformation);
            if ( _shouldDisplayTransition )
            {
                Debug.Log(_previousActionState.GetType().Name + " --> " + _currentActionState.GetType().Name, gameObject);
            }
        }
    }
}
