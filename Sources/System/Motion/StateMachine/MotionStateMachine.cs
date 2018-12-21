using System.Collections.Generic;
using UniCraft.AttributeCollection;
using UniCraft.CharacterMechanism.System.Motion.Information;
using UnityEngine;

namespace UniCraft.CharacterMechanism.System.Motion.StateMachine
{
    /// <summary>
    /// Class to manage the motions of a character
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
        private Dictionary<string, AMotionState> _stateRecords = null;

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
        public bool Initialize()
        {
            if ( _entryState == null )
            {
                Debug.LogError(ErrorMessageNoEntryState);
                return (false);
            }
            _stateRecords = new Dictionary<string, AMotionState>();
            _currentState = GetStateFromRecords(_entryState);
            return (true);
        }

        /// <summary>
        /// Call when the motion state machine start
        /// </summary>
        public void Start(ACharacterSystem characterSystem)
        {
            _currentState.Begin(characterSystem);
        }

        /// <summary>
        /// Execute the current state Tick
        /// </summary>
        public void Execute(MotionInformation motionInformation)
        {
            _currentState.Tick(motionInformation.GetMotionConfiguration, motionInformation.GetMotionInput);
        }

        /// <summary>
        /// Attempt to transit to the next state ; if yes, call the function Begin of the next state
        /// </summary>
        public void Update(ACharacterSystem characterSystem, MotionInformation motionInformation)
        {
            var nextState = _currentState.AttemptToGetNextState(characterSystem, motionInformation);
            
            if ( nextState != null )
            {
                _previousState = _currentState;
                _currentState = GetStateFromRecords(nextState);
                _currentState.Begin(characterSystem);
                if ( _displayTransitionLog )
                {
                    DisplayTransitionLog();
                }
            }
        }
        
        /////////////////////////////
        ////////// Service //////////

        ////////// Log //////////
        
        /// <summary>
        /// Display the transition between the previous state and the current state in the console
        /// </summary>
        private void DisplayTransitionLog()
        {
            Debug.Log(_previousState.GetType().Name + " --> " + _currentState.GetType().Name);
        }
        
        ////////// Pooling //////////

        /// <summary>
        /// Return the corresponding loaded state
        /// <code>
        /// ScriptableObject represent one instance, so we need to duplicate it.
        /// To increase the performance, the motion states records the new loaded states and reused it.
        /// Function complexity O(1) thanks to the unordered hash table Dictionary.
        /// </code>
        /// </summary>
        private AMotionState GetStateFromRecords(AMotionState refState)
        {
            var stateKey = refState.GetType().Name;
            
            if ( !_stateRecords.ContainsKey(stateKey) )
            {
                _stateRecords.Add(stateKey, Object.Instantiate(refState));
            }
            return (_stateRecords[stateKey]);
        }
    }
}
