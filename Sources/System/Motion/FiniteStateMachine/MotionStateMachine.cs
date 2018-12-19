using UniCraft.AttributeCollection;
using UnityEngine;

namespace UniCraft.CharacterMechanism.System.Motion.FiniteStateMachine
{
    /// <summary>
    /// Class to manage the motion state machine (states and transitions)
    /// </summary>
    [global::System.Serializable]
    public sealed class MotionStateMachine
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////

        /////////////////////////////////////
        ////////// Default Setting //////////

        private const string ErrorMessageNoEntryState = "[Character System] There is no entry state!";
        
        ///////////////////////////////////
        ////////// Configuration //////////
        
        [Header("Configuration")]
        [SerializeField] private AMotionState EntryState = null;
        
        /////////////////////////////////
        ////////// Information //////////
        
        [Header("Information")]
        [SerializeField, DisableInInspector] private AMotionState CurrentState = null;
        [SerializeField, DisableInInspector] private AMotionState PreviousState = null;
        
        /////////////////////////////
        ////////// Setting //////////
        
        [Header("Setting")]
        [SerializeField] private bool DisplayDebugLog = false;
        [SerializeField] private bool PauseMachine = false;
        
        //////////////////////////////
        ////////// Property //////////
        //////////////////////////////
        
        public AMotionState GetCurrentState => CurrentState;
        public AMotionState GetPreviousState => PreviousState;
        
        ////////////////////////////
        ////////// Method //////////
        ////////////////////////////
        
        ///////////////////////////////
        ////////// Mechanism //////////

        /// <summary>
        /// Initialize the finite state machine
        /// </summary>
        public void Initialize()
        {
            CurrentState = EntryState;
            if ( CurrentState == null )
            {
                Debug.LogError(ErrorMessageNoEntryState);
            }
        }

        /// <summary>
        /// Execute the current state action
        /// </summary>
        public void Execute(ACharacterSystem cs, MotionInput mi)
        {
            if ( (CurrentState != null) && (!PauseMachine) )
            {
                CurrentState.Tick(cs, mi);
            }
        }

        /// <summary>
        /// Attempt to transit to the next state
        /// </summary>
        public void UpdateCurrentState(ACharacterSystem cs, MotionInput mi)
        {
            if ( (CurrentState != null) && (!PauseMachine) )
            {
                var nextState = CurrentState.AttemptToGetNextState(cs, mi);
                if ( nextState != null )
                {
                    PreviousState = CurrentState;
                    CurrentState = nextState;
                    CurrentState.Begin(cs, mi);
                    if ( DisplayDebugLog )
                    {
                        DisplayTransitionLog();
                    }
                }
            }
        }
        
        /////////////////////////////
        ////////// Service //////////

        /// <summary>
        /// Display the registered transition: previous to current
        /// </summary>
        private void DisplayTransitionLog()
        {
            Debug.Log(PreviousState.GetType().Name + " --> " + CurrentState.GetType().Name);
        }
    }
}
