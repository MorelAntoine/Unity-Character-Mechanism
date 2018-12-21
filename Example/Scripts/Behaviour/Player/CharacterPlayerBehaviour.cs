using UniCraft.CharacterMechanism.Behaviour;
using UniCraft.CharacterMechanism.System;
using UniCraft.CharacterMechanism.System.Motion.Information;
using UnityEngine;

namespace UniCraft.CharacterMechanism.Example.Behaviour
{
    /// <inheritdoc/>
    /// <summary>
    /// Basic movement player controller
    /// </summary>
    public sealed class CharacterPlayerBehaviour : ACharacterBehaviour
    {
        protected override void Initialize(ACharacterSystem characterSystem, MotionConfiguration motionConfiguration)
        {}

        protected override void UpdateMotionInput(MotionInput motionInput)
        {
            motionInput.MovementDirection.Set(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            motionInput.MovementDirection.Normalize();
        }
    }
}
