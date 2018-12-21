using UniCraft.CharacterMechanism.Example.System;
using UniCraft.CharacterMechanism.System;
using UniCraft.CharacterMechanism.System.Motion.Information;
using UniCraft.CharacterMechanism.System.Motion.StateMachine;
using UnityEngine;

namespace UniCraft.CharacterMechanism.Example.Motion.State
{
    /// <inheritdoc/>
    /// <summary>
    /// Basic walk state working for both NavMesh and classic controller
    /// </summary>
    [CreateAssetMenu(menuName = "UniCraft/Character/Example/State/Walk")]
    public sealed class WalkState : AMotionState
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////

        private HumanSystem3D _human;
        
        ////////////////////////////
        ////////// Method //////////
        ////////////////////////////
        
        public override void Begin(ACharacterSystem characterSystem)
        {
            _human = characterSystem as HumanSystem3D;
        }

        public override void Tick(MotionConfiguration mc, MotionInput mi)
        {
            var angularSpeed = _human.GetLocomotionProfile.InterpolateAngularSpeed(mi.MovementDirection.z);

            _human.transform.Rotate(0f, mi.MovementDirection.x * angularSpeed * Time.deltaTime, 0f, Space.Self);
            _human.transform.Translate(0f, 0f, mi.MovementDirection.z * _human.GetLocomotionProfile.WalkSpeed* Time.deltaTime, Space.Self);
        }
    }
}
