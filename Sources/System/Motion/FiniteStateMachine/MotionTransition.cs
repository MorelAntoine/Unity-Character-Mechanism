using System.Linq;
using UnityEngine;

namespace UniCraft.CharacterMechanism.System.Motion.FiniteStateMachine
{
    /// <inheritdoc/>
    /// <summary>
    /// ScriptableObject to create transition for the motion state machine
    /// </summary>
    public class MotionTransition : ScriptableObject
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////

        [SerializeField] private AMotionCondition[] _conditions = null;
        
        [Header("State")]
        [SerializeField] private AMotionState _stateOnSuccess = null;
        [SerializeField] private AMotionState _stateOnFailure = null;

        ////////////////////////////
        ////////// Method //////////
        ////////////////////////////

        /// <summary>
        /// Return the resulting state based on the simulation
        /// </summary>
        public AMotionState Simulate(ACharacterSystem cs, MotionInput mi)
        {
            return (_conditions.All(condition => condition.IsConditionMet(cs, mi)) ? _stateOnSuccess : _stateOnFailure);
        }
    }
}
