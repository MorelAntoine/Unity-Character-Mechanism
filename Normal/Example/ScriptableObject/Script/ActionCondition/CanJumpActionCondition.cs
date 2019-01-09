using CharacterMechanism.Normal.Information;
using CharacterMechanism.Normal.ScriptableObject;
using UnityEngine;

namespace CharacterMechanism.Normal.Example
{
    /// <inheritdoc/>
    /// <summary>
    /// Example of action condition for a jump detection
    /// </summary>
    [CreateAssetMenu(menuName = "CharacterMechanism/Example/ActionCondition/CanJump")]
    public sealed class CanJumpActionCondition : AActionCondition
    {
        public override bool IsConditionFulfilled(InputInformation inputInformation)
        {
            return (inputInformation.GetLocomotionInformation.ShouldJump);
        }
    }
}
