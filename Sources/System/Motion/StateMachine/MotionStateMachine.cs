using UniCraft.AttributeCollection;
using UniCraft.CharacterMechanism.System.Motion.Information;
using UnityEngine;

namespace UniCraft.CharacterMechanism.System.Motion.StateMachine
{
    /// <summary>
    /// Class to manage the motions of the character
    /// </summary>
    [global::System.Serializable]
    public sealed class MotionStateMachine
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////

        /////////////////////////////////////
        ////////// Default Setting //////////

        private const string ErrorMessageNoEntryState = "[Motion State Machine] There is no entry state!";
        
        ///////////////////////////////////
        ////////// Configuration //////////
        
        [Header("Configuration")]
        [SerializeField] private AMotionState _entryState = null;
        
        /////////////////////////////////
        ////////// Information //////////
        
        [Header("Information")]
        [SerializeField, DisableInInspector] private AMotionState _currentState = null;
        [SerializeField, DisableInInspector] private AMotionState _previousState = null;
        
        /////////////////////////////
        ////////// Setting //////////
        
        [Header("Setting")]
        [SerializeField] private bool _displayTransitionLog = false;
        
        //////////////////////////////
        ////////// Property //////////
        //////////////////////////////
        
        public AMotionState GetCurrentState => _currentState;
        public AMotionState GetPreviousState => _previousState;

        ////////////////////////////
        ////////// Method //////////
        ////////////////////////////
        
        /////////////////////////
        ////////// API //////////

        /// <summary>
        /// Initialize the motion state machine
        /// </summary>
        public void Initialize()
        {
            _currentState = _entryState;
            if ( _currentState == null )
            {
                Debug.LogError(ErrorMessageNoEntryState);
            }
        }

        /// <summary>
        /// Call when the motion state machine start
        /// </summary>
        public void Start(ACharacterSystem characterSystem)
        {
            if ( _currentState != null )
            {
                _currentState.Begin(characterSystem);
            }
        }

        /// <summary>
        /// Execute the current state Tick
        /// </summary>
        public void Execute(MotionInformation motionInformation)
        {
            if ( _currentState != null )
            {
                _currentState.Tick(motionInformation);
            }
        }

        /// <summary>
        /// Attempt to transit to the next state ; if yes, call the function Begin of the next state
        /// </summary>
        public void Update(ACharacterSystem characterSystem, MotionInformation motionInformation)
        {
            if ( _currentState != null )
            {
                var nextState = _currentState.AttemptToGetNextState(characterSystem, motionInformation);
                if ( nextState != null )
                {
                    _previousState = _currentState;
                    _currentState = nextState;
                    _currentState.Begin(characterSystem);
                    if ( _displayTransitionLog )
                    {
                        DisplayTransitionLog();
                    }
                }
            }
        }
        
        /////////////////////////////
        ////////// Service //////////

        /// <summary>
        /// Display the transition between the previous state and the current state in the console
        /// </summary>
        private void DisplayTransitionLog()
        {
            Debug.Log(_previousState.GetType().Name + " --> " + _currentState.GetType().Name);
        }
    }
}
