using UniCraft.CharacterMechanism.System;
using UniCraft.CharacterMechanism.System.Motion;
using UniCraft.CharacterMechanism.System.Motion.FiniteStateMachine;
using UnityEngine;

namespace UniCraft.CharacterMechanism.Example.Motion
{
    [CreateAssetMenu(menuName = "UniCraft/Character/Example/Motion/Condition/AreDirectionalKeyReleased")]
    public class AreDirectionalKeyReleasedCondition : AMotionCondition
    {
        public override bool IsConditionMet(ACharacterSystem cs, MotionInput mi)
        {
            return (Input.GetAxisRaw("Horizontal") == 0f && Input.GetAxisRaw("Vertical") == 0f);
        }
    }
}
