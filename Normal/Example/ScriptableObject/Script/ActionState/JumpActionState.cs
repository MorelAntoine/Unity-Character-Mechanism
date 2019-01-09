using CharacterMechanism.Normal.Information;
using CharacterMechanism.Normal.ScriptableObject;
using CharacterMechanism.Normal.System;
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
        public override void BeginAction(ACharacterSystem characterSystem, InputInformation inputInformation)
        {}

        public override void EndAction(ACharacterSystem characterSystem, InputInformation inputInformation)
        {}

        public override void UpdateAction(ACharacterSystem characterSystem, InputInformation inputInformation)
        {
            var human = characterSystem as HumanSystem;
            
            human.GetRigidbody.AddForce(0f, human.GetLocomotionProfile.JumpForce, 0f, ForceMode.Impulse);
        }
    }
}
