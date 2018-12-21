using UniCraft.CharacterMechanism.System;
using UniCraft.CharacterMechanism.System.Motion.Information;
using UniCraft.CharacterMechanism.System.Motion.StateMachine;
using UnityEngine;

namespace UniCraft.CharacterMechanism.Example.Motion.Condition
{
    /// <inheritdoc/>
    /// <summary>
    /// Verify if there is a directional movement input or not
    /// </summary>
    [CreateAssetMenu(menuName = "UniCraft/Character/Example/Condition/HasDirectionalMovementInput")]
    public class HasDirectionalMovementInputCondition : AMotionCondition
    {
        public override bool IsConditionMet(ACharacterSystem characterSystem, MotionInput motionInput)
        {
            return (motionInput.MovementDirection != Vector3.zero);
        }
    }
}
