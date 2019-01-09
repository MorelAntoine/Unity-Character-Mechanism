using CharacterMechanism.Normal.Information;
using CharacterMechanism.Normal.ScriptableObject;
using CharacterMechanism.Normal.System;
using UnityEngine;

namespace CharacterMechanism.Normal.Example
{
    /// <inheritdoc/>
    /// <summary>
    /// Example of walk action state 
    /// </summary>
    [CreateAssetMenu(menuName = "CharacterMechanism/Example/ActionState/Walk")]
    public sealed class WalkActionState : AActionState
    {
        public override void BeginAction(ACharacterSystem characterSystem, InputInformation inputInformation)
        {}

        public override void EndAction(ACharacterSystem characterSystem, InputInformation inputInformation)
        {}

        public override void UpdateAction(ACharacterSystem characterSystem, InputInformation inputInformation)
        {
            var human = characterSystem as HumanSystem;

            human.transform.Rotate(0f
                , inputInformation.GetLocomotionInformation.MovementDirection.x * human.GetLocomotionProfile.AngularSpeed * Time.deltaTime
                , 0f, Space.Self);
            human.transform.Translate(0f, 0f,
                inputInformation.GetLocomotionInformation.MovementDirection.z * human.GetLocomotionProfile.WalkSpeed * Time.deltaTime,
                Space.Self);
        }
    }
}
