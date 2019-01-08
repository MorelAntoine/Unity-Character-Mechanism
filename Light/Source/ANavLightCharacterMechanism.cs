using UnityEngine;
using UnityEngine.AI;

namespace CharacterMechanism.Light
{
    /// <inheritdoc/>
    /// <summary>
    /// Base class to create a generic nav light character mechanism
    /// </summary>
    [RequireComponent(typeof(NavMeshAgent))]
    public abstract class ANavLightCharacterMechanism : ALightCharacterMechanism
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////

        protected NavMeshAgent _NavMeshAgent = null;
        
        //////////////////////////////
        ////////// Property //////////
        //////////////////////////////

        /// <summary>
        /// Return the next local direction of the Nav Mesh Agent
        /// </summary>
        protected Vector3 GetNextDirection => transform.InverseTransformDirection(_NavMeshAgent.desiredVelocity.normalized);

        /// <summary>
        /// Verify if the GameObject is arrived to his destination
        /// </summary>
        protected bool IsArrived => (_NavMeshAgent.remainingDistance <= _NavMeshAgent.stoppingDistance);
        
        ////////////////////////////
        ////////// Method //////////
        ////////////////////////////
        
        //////////////////////////////
        ////////// Callback //////////
        
        /// <summary>
        /// Configure the Nav Mesh Agent
        /// </summary>
        /// <remarks>
        /// Call at the beginning after InitializeComponents
        /// </remarks>
        protected virtual void ConfigureNavMeshAgent()
        {
            _NavMeshAgent.acceleration = 0.01f;
            _NavMeshAgent.angularSpeed = 0.01f;
            _NavMeshAgent.speed = 0.01f;
            _NavMeshAgent.stoppingDistance = 0.6f;
            _NavMeshAgent.updatePosition = true;
            _NavMeshAgent.updateRotation = false;
        }
        
        //////////////////////////////
        ////////// Override //////////
        
        protected override void Awake()
        {
            _NavMeshAgent = GetComponent<NavMeshAgent>();
            base.Awake();
            ConfigureNavMeshAgent();
        }
    }
}