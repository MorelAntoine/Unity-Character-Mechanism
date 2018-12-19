using UnityEngine;

namespace UniCraft.CharacterMechanism.System.Motion.FiniteStateMachine
{
    /// <inheritdoc/>
    /// <summary>
    /// Base ScriptableObject to create motion state for the motion state machine
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
        public AMotionState AttemptToGetNextState(ACharacterSystem cs, MotionInput mi)
        {
            foreach (var transition in _transitions)
            {
                var resultingState = transition.Simulate(cs, mi);
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
        public abstract void Begin(ACharacterSystem cs, MotionInput mi);

        /// <summary>
        /// Call every Fixed Update
        /// </summary>
        public abstract void Tick(ACharacterSystem cs, MotionInput mi);
    }
}
