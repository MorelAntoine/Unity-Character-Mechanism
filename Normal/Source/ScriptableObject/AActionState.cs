using CharacterMechanism.Normal.Information;
using CharacterMechanism.Normal.Mechanism;
using UnityEngine;

namespace CharacterMechanism.Normal.ScriptableObject
{
    /// <inheritdoc/>
    /// <summary>
    /// Base class to create an action state
    /// </summary>
    public abstract class AActionState : UnityEngine.ScriptableObject
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////

        [SerializeField] private ActionTransition[] _actionTransitions = null;
        
        ////////////////////////////
        ////////// Method //////////
        ////////////////////////////
        
        /////////////////////////
        ////////// API //////////

        /// <summary>
        /// Attempt to return the next action state
        /// </summary>
        public AActionState AttemptToGetNextActionState(InputInformation inputInformation)
        {
            foreach ( var actionTransition in _actionTransitions )
            {
                var nextActionState = actionTransition.Simulate(inputInformation);
                
                if ( nextActionState )
                {
                    return (nextActionState);
                }
            }
            return (null);
        }
        
        //////////////////////////////
        ////////// Callback //////////
        
        /// <summary>
        /// Launch the action
        /// </summary>
        /// <remarks>
        /// Call when the action state is loaded
        /// </remarks>
        public abstract void BeginAction(ACharacterMechanism characterMechanism, InputInformation inputInformation);

        /// <summary>
        /// Close the action
        /// </summary>
        /// <remarks>
        /// Call when the action state is changed
        /// </remarks>
        public abstract void EndAction(ACharacterMechanism characterMechanism, InputInformation inputInformation);

        /// <summary>
        /// Update the action
        /// </summary>
        /// <remarks>
        /// Call every FixedUpdate
        /// </remarks>
        public abstract void UpdateAction(ACharacterMechanism characterMechanism, InputInformation inputInformation);
    }
}
