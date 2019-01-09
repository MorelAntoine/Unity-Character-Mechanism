/*
** LightPatrolAIMechanism.cs for Unity-Character-Mechanism
**
** Made by Antoine MOREL
**
** Started on  Jan 05 2019 Antoine MOREL
** Last update Jan 09 2019 Antoine MOREL
** 
** Copyright (c) 2018 - 2019 All Rights Reserved
*/

using CharacterMechanism.Normal.Attribute;
using UnityEngine;

namespace CharacterMechanism.Light.Example
{
    /// <inheritdoc/>
    /// <summary>
    /// Example of patrol AI mechanism using the generic nav light character mechanism
    /// </summary>
    /// <remarks>
    /// ANavLightCharacterMechanism is used because the script doesn't need collision and trigger detection
    /// </remarks>
    [RequireComponent(typeof(Rigidbody))]
    public sealed class LightPatrolAIMechanism : ANavLightCharacterMechanism
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////
        
        ///////////////////////////////////////
        ////////// Agent Information //////////
        
        [Header("Agent Information")]
        [ReadOnly, SerializeField] private int _waypointIndex = 0;
        
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
        [SerializeField] private Transform[] _waypoints = null;
        
        ////////////////////////////////////////
        ////////// Locomotion Setting //////////

        [Header("Locomotion Setting")]
        [SerializeField, Range(80f, 160f)] private float _angularSpeed = 140f;
        [SerializeField, Range(1f, 4f)] private float _walkSpeed = 2f;
        
        ////////////////////////////
        ////////// Method //////////
        ////////////////////////////
    
        //////////////////////////////
        ////////// Callback //////////
    
        ////////// Action //////////

        protected override void BeginAction()
        {
            _NavMeshAgent.SetDestination(_waypoints[_waypointIndex].position);
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
            _NavMeshAgent.autoBraking = false;
            _NavMeshAgent.stoppingDistance = 1f;
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
            if ( IsArrived )
            {
                _waypointIndex = (_waypointIndex + 1) % _waypoints.Length;
                _NavMeshAgent.SetDestination(_waypoints[_waypointIndex].position);
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
