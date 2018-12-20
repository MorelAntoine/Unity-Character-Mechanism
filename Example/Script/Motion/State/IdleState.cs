using UniCraft.CharacterMechanism.System;
using UniCraft.CharacterMechanism.System.Motion;
using UniCraft.CharacterMechanism.System.Motion.FiniteStateMachine;
using UnityEngine;

namespace UniCraft.CharacterMechanism.Example.Motion
{
    [CreateAssetMenu(menuName = "UniCraft/Character/Example/Motion/State/Idle")]
    public sealed class IdleState : AMotionState
    {
        public override void Begin(ACharacterSystem cs, MotionInput mi)
        {
        }

        public override void Tick(ACharacterSystem cs, MotionInput mi)
        {
        }
    }
}
