using CharacterMechanism.Normal.Attribute;
using UnityEngine;

namespace CharacterMechanism.Light.Example
{
    /// <inheritdoc/>
    /// <summary>
    /// Example of follow AI mechanism using the generic nav light character mechanism
    /// </summary>
    /// <remarks>
    /// ANavLightCharacterMechanism is used because the script doesn't need collision and trigger detection
    /// </remarks>
    [RequireComponent(typeof(Rigidbody))]
    public sealed class LightFollowAIMechanism : ANavLightCharacterMechanism
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////
        
        ///////////////////////////////////////
        ////////// Agent Information //////////
        
        [Header("Agent Information")]
        [ReadOnly, SerializeField] private Vector3 _destinationPosition = Vector3.zero;
        
        ///////////////////////////////
        ////////// Component //////////

        private Rigidbody _rigidbody = null;
        
        ///////////////////////////////////////
        ////////// Input Information //////////

        [Header("Input Information")]
        [ReadOnly, SerializeField] private Vector3 _movementDirection = Vector3.zero;
        
        ///////////////////////////////////
        ////////// Input Setting //////////

        [Header("Input Setting")]
        [SerializeField] private Transform _target = null;
        
        ////////////////////////////////////////
        ////////// Locomotion Setting //////////

        [Header("Locomotion Setting")]
        [SerializeField, Range(80f, 160f)] private float _angularSpeed = 140f;
        [SerializeField, Range(1f, 4f)] private float _walkSpeed = 1.8f;
        
        ////////////////////////////
        ////////// Method //////////
        ////////////////////////////
    
        //////////////////////////////
        ////////// Callback //////////
    
        ////////// Action //////////

        protected override void BeginAction()
        {
            _NavMeshAgent.SetDestination(_target.position);
            _destinationPosition = _NavMeshAgent.destination;
        }

        protected override void UpdateAction()
        {
            if ( _movementDirection == Vector3.zero )
            {
                Idle();
            }
            else
            {
                Walk();
            }
        }
    
        ////////// Activation //////////

        protected override void OnDestroy()
        {}
        
        protected override void OnDisable()
        {}
        
        protected override void OnEnable()
        {}

        ////////// Component //////////

        protected override void ConfigureNavMeshAgent()
        {
            base.ConfigureNavMeshAgent();
            _NavMeshAgent.stoppingDistance = 1.4f;
        }

        protected override void InitializeComponents()
        {
            _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
            _rigidbody.isKinematic = true;
        }
        
        protected override void LoadComponents()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        ////////// Input Information //////////
    
        protected override void ResetInputInformation()
        {
            _movementDirection.Set(0f, 0f, 0f);
        }

        protected override void UpdateInputInformation()
        {
            if ( Vector3.Distance(_destinationPosition, _target.position) > _NavMeshAgent.stoppingDistance )
            {
                _NavMeshAgent.SetDestination(_target.position);
                _destinationPosition = _NavMeshAgent.destination;
            }
            _movementDirection = GetNextDirection;
        }
        
        //////////////////////////////////
        ////////// State Action //////////

        private void Idle()
        {}

        private void Walk()
        {
            transform.Rotate(0f, _movementDirection.x * _angularSpeed * Time.deltaTime, 0f, Space.Self);
            transform.Translate(0f, 0f, _movementDirection.z * _walkSpeed * Time.deltaTime, Space.Self);
        }
    }
}
