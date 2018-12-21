using System.Linq;
using UniCraft.CharacterMechanism.System.Motion.Information;
using UnityEngine;

namespace UniCraft.CharacterMechanism.System.Motion.StateMachine
{
    /// <inheritdoc/>
    /// <summary>
    /// ScriptableObject to create a motion transition for a motion state machine
    /// </summary>
    [CreateAssetMenu(menuName = "UniCraft/Character/Transition")]
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
        public AMotionState Simulate(ACharacterSystem characterSystem, MotionInput motionInput)
        {
            return (_conditions.All(condition => condition.IsConditionMet(characterSystem, motionInput))
                ?_stateOnSuccess : _stateOnFailure);
        }
    }
}
