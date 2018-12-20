using UniCraft.CharacterMechanism.System.Motion.Information;
using UnityEngine;

namespace UniCraft.CharacterMechanism.System.Motion.StateMachine
{
    /// <inheritdoc/>
    /// <summary>
    /// Base ScriptableObject to create a motion state for the motion state machine
    /// </summary>
    public abstract class AMotionState : ScriptableObject
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////

        [Header("Configuration")]
        [SerializeField] private MotionTransition[] _transitions = null;
        
        ////////////////////////////
        ////////// Method //////////
        ////////////////////////////

        /////////////////////////
        ////////// API //////////
        
        /// <summary>
        /// Attempt to return the next state based on the transitions
        /// </summary>
        public AMotionState AttemptToGetNextState(ACharacterSystem characterSystem, MotionInformation motionInformation)
        {
            foreach (var transition in _transitions)
            {
                var resultingState = transition.Simulate(characterSystem, motionInformation.GetMotionInput);
                if ( resultingState != null )
                {
                    return (resultingState);
                }
            }
            return (null);
        }
        
        //////////////////////////////
        ////////// Callback //////////

        /// <summary>
        /// Call once the state is loaded
        /// </summary>
        public abstract void Begin(ACharacterSystem characterSystem);

        /// <summary>
        /// Call every Fixed Update
        /// </summary>
        public abstract void Tick(MotionInformation motionInformation);
    }
}
