using CharacterMechanism.Normal.Information;
using CharacterMechanism.Normal.Mechanism;
using CharacterMechanism.Normal.ScriptableObject;
using UnityEngine;

namespace CharacterMechanism.Normal.Example
{
    /// <inheritdoc/>
    /// <summary>
    /// Example of run action state 
    /// </summary>
    [CreateAssetMenu(menuName = "CharacterMechanism/Example/ActionState/Run")]
    public sealed class RunActionState : AActionState
    {
        public override void BeginAction(ACharacterMechanism characterMechanism, InputInformation inputInformation)
        {}

        public override void EndAction(ACharacterMechanism characterMechanism, InputInformation inputInformation)
        {}

        public override void UpdateAction(ACharacterMechanism characterMechanism, InputInformation inputInformation)
        {
            var exampleMechanism = characterMechanism as AExampleCharacterMechanism;

            exampleMechanism.transform.Rotate(0f
                , inputInformation.GetLocomotionInformation.MovementDirection.x * exampleMechanism.GetLocomotionProfile.AngularSpeed * Time.deltaTime
                , 0f, Space.Self);
            exampleMechanism.transform.Translate(0f, 0f,
                inputInformation.GetLocomotionInformation.MovementDirection.z * exampleMechanism.GetLocomotionProfile.RunSpeed * Time.deltaTime,
                Space.Self);
        }
    }
}
