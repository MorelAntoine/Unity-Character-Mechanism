using CharacterMechanism.Normal.Information;
using System.Linq;
using UnityEngine;

namespace CharacterMechanism.Normal.ScriptableObject
{
    /// <inheritdoc/>
    /// <summary>
    /// ScriptableObject used to create action transition
    /// </summary>
    [CreateAssetMenu(menuName = "CharacterMechanism/ScriptableObject/ActionTransition")]
    public sealed class ActionTransition : UnityEngine.ScriptableObject
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////

        [SerializeField] private AActionCondition[] _actionConditions = null;
        [SerializeField] private AActionState _actionStateOnSuccess = null;
        [SerializeField] private AActionState _actionStateOnFailure = null;
        
        ////////////////////////////
        ////////// Method //////////
        ////////////////////////////
        
        /// <summary>
        /// Simulate the transition in order to get the resulting action state
        /// </summary>
        public AActionState Simulate(InputInformation inputInformation)
        {
            if ( _actionConditions.All(ac => ac.IsConditionFulfilled(inputInformation)) )
            {
                return (_actionStateOnSuccess);
            }
            return (_actionStateOnFailure);
        }
    }
}
