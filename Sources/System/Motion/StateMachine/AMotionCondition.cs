using UniCraft.CharacterMechanism.System.Motion.Information;
using UnityEngine;

namespace UniCraft.CharacterMechanism.System.Motion.StateMachine
{
    /// <inheritdoc/>
    /// <summary>
    /// Base ScriptableObject to create motion condition for the motion state machine
    /// </summary>
    public abstract class AMotionCondition : ScriptableObject
    {
        /// <summary>
        /// Verify if the condition is met or not
        /// </summary>
        public abstract bool IsConditionMet(ACharacterSystem characterSystem, MotionInput motionInput);
    }
}
