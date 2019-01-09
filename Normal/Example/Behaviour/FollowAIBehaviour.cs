using CharacterMechanism.Normal.Attribute;
using CharacterMechanism.Normal.Behaviour;
using CharacterMechanism.Normal.Information;
using UnityEngine;

namespace CharacterMechanism.Normal.Example
{
    /// <inheritdoc/>
    /// <summary>
    /// Example of follow AI behaviour using the generic character behaviour
    /// </summary>
    /// <remarks>
    /// ANavCharacterBehaviour is used because the script doesn't need collision and trigger detection
    /// </remarks>
    public sealed class FollowAIBehaviour : ANavCharacterBehaviour
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////

        ///////////////////////////////////////
        ////////// Agent Information //////////
        
        [Header("Agent Information")]
        [ReadOnly, SerializeField] private Vector3 _destinationPosition = Vector3.zero;
        
        ///////////////////////////////////
        ////////// Input Setting //////////
        
        [Header("Input Setting")]
        [SerializeField] private Transform _target = null;
                
        ////////////////////////////
        ////////// Method //////////
        ////////////////////////////
    
        //////////////////////////////
        ////////// Callback //////////
        
        ////////// Activation //////////
        
        protected override void OnDestroy()
        {}

        protected override void OnDisable()
        {}

        protected override void OnEnable()
        {}

        ////////// Information //////////

        protected override void ConfigureNavMeshAgent()
        {
            base.ConfigureNavMeshAgent();
            _NavMeshAgent.stoppingDistance = 1.4f;
        }

        protected override void InitializeInformation()
        {
            _NavMeshAgent.SetDestination(_target.position);
            _destinationPosition = _NavMeshAgent.destination;
        }

        protected override void LoadInformationComponents()
        {}
        
        protected override void OverrideInputInformationReset(InputInformation inputInformation)
        {}

        protected override void UpdateInputInformation(InputInformation inputInformation)
        {
            if ( Vector3.Distance(_destinationPosition, _target.position) > _NavMeshAgent.stoppingDistance )
            {
                _NavMeshAgent.SetDestination(_target.position);
                _destinationPosition = _NavMeshAgent.destination;
            }
            inputInformation.GetLocomotionInformation.MovementDirection = GetNextDirection;
        }
    }
}
