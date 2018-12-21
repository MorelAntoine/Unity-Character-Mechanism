using UniCraft.CharacterMechanism.System.Motion.Information;
using UnityEngine;

namespace UniCraft.CharacterMechanism.System.Motion.StateMachine
{
    /// <inheritdoc/>
    /// <summary>
    /// Base ScriptableObject to create a motion condition for a motion state machine
    /// </summary>
    public abstract class AMotionCondition : ScriptableObject
    {
        /// <summary>
        /// Verify if the condition is met or not
        /// </summary>
        public abstract bool IsConditionMet(ACharacterSystem characterSystem, MotionInput motionInput);
    }
}
