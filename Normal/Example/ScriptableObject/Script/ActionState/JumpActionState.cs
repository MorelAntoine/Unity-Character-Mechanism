using CharacterMechanism.Normal.Information;
using CharacterMechanism.Normal.Mechanism;
using CharacterMechanism.Normal.ScriptableObject;
using UnityEngine;

namespace CharacterMechanism.Normal.Example
{
    /// <inheritdoc/>
    /// <summary>
    /// Example of jump action state 
    /// </summary>
    [CreateAssetMenu(menuName = "CharacterMechanism/Example/ActionState/Jump")]
    public sealed class JumpActionState : AActionState
    {
        public override void BeginAction(ACharacterMechanism characterMechanism, InputInformation inputInformation)
        {}

        public override void EndAction(ACharacterMechanism characterMechanism, InputInformation inputInformation)
        {}

        public override void UpdateAction(ACharacterMechanism characterMechanism, InputInformation inputInformation)
        {
            var exampleMechanism = characterMechanism as AExampleCharacterMechanism;
            
            exampleMechanism.GetRigidbody.AddForce(0f, exampleMechanism.GetLocomotionProfile.JumpForce, 0f, ForceMode.Impulse);
        }
    }
}
