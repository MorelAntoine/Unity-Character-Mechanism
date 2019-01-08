using CharacterMechanism.Normal.Information;
using CharacterMechanism.Normal.Mechanism;
using CharacterMechanism.Normal.ScriptableObject;
using UnityEngine;

namespace CharacterMechanism.Normal.Example
{
    /// <inheritdoc/>
    /// <summary>
    /// Example of idle action state 
    /// </summary>
    [CreateAssetMenu(menuName = "CharacterMechanism/Example/ActionState/Idle")]
    public sealed class IdleActionState : AActionState
    {
        public override void BeginAction(ACharacterMechanism characterMechanism, InputInformation inputInformation)
        {}

        public override void EndAction(ACharacterMechanism characterMechanism, InputInformation inputInformation)
        {}

        public override void UpdateAction(ACharacterMechanism characterMechanism, InputInformation inputInformation)
        {}
    }
}
