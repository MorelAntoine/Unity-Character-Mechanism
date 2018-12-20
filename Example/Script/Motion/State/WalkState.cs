using UniCraft.CharacterMechanism.System;
using UniCraft.CharacterMechanism.System.Motion;
using UniCraft.CharacterMechanism.System.Motion.FiniteStateMachine;
using UnityEngine;

namespace UniCraft.CharacterMechanism.Example.Motion
{
    [CreateAssetMenu(menuName = "UniCraft/Character/Example/Motion/State/Walk")]
    public sealed class WalkState : AMotionState
    {
        public override void Begin(ACharacterSystem cs, MotionInput mi)
        {
        }

        public override void Tick(ACharacterSystem cs, MotionInput mi)
        {
            var cs3D = cs as ACharacterSystem3D;
            var angularSpeed = cs3D.GetLocomotionProfile.InterpolateAngularSpeed(Input.GetAxis("Horizontal"));
            
            cs.transform.Rotate(0f, mi.MovementDirection.x * angularSpeed * Time.deltaTime, 0f, Space.Self);
            cs.transform.Translate(0f, 0f,
                mi.MovementDirection.z * cs3D.GetLocomotionProfile.WalkSpeed * Time.deltaTime, Space.Self);
        }
    }
}