using CharacterMechanism.Normal.Information;
using CharacterMechanism.Normal.ScriptableObject;
using UnityEngine;

namespace CharacterMechanism.Normal.Example
{
    /// <inheritdoc/>
    /// <summary>
    /// Example of action condition for a detection of no movement direction
    /// </summary>
    [CreateAssetMenu(menuName = "CharacterMechanism/Example/ActionCondition/HasNoMovementDirection")]
    public sealed class HasNoMovementDirectionActionCondition : AActionCondition
    {
        public override bool IsConditionFulfilled(InputInformation inputInformation)
        {
            return (inputInformation.GetLocomotionInformation.MovementDirection == Vector3.zero);
        }
    }
}
