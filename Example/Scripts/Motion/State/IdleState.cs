using UniCraft.CharacterMechanism.System;
using UniCraft.CharacterMechanism.System.Motion.Information;
using UniCraft.CharacterMechanism.System.Motion.StateMachine;
using UnityEngine;

namespace UniCraft.CharacterMechanism.Example.Motion.State
{
    /// <inheritdoc/>
    /// <summary>
    /// Basic idle state
    /// </summary>
    [CreateAssetMenu(menuName = "UniCraft/Character/Example/State/Idle")]
    public class IdleState : AMotionState
    {
        public override void Begin(ACharacterSystem characterSystem)
        {}

        public override void Tick(MotionConfiguration mc, MotionInput mi)
        {}
    }
}
