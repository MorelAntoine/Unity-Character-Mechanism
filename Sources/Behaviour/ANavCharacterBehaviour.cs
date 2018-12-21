using UniCraft.CharacterMechanism.System;
using UniCraft.CharacterMechanism.System.Motion.Information;
using UnityEngine;
using UnityEngine.AI;

namespace UniCraft.CharacterMechanism.Behaviour
{
    /// <inheritdoc/>
    /// <summary>
    /// Base module to define the behaviour of a character that use a NavMesh
    /// </summary>
    [RequireComponent(typeof(NavMeshAgent))]
    public abstract class ANavCharacterBehaviour : ACharacterBehaviour
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////

        private NavMeshAgent _navMeshAgent = null;
        
        //////////////////////////////
        ////////// Property //////////
        //////////////////////////////

        protected Vector3 GetNextDirection => _navMeshAgent.desiredVelocity.normalized;
        protected bool IsArrived => (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance);
        
        ////////////////////////////
        ////////// Method //////////
        ////////////////////////////

        //////////////////////////////////////////////////
        ////////// ACharacterBehaviour Callback //////////

        protected sealed override void Initialize(ACharacterSystem characterSystem,
            MotionConfiguration motionConfiguration)
        {
            motionConfiguration.AdaptToNavMesh = true;
            SetupNavMeshAgent(characterSystem);
            Initialize(characterSystem, motionConfiguration, _navMeshAgent);
        }

        protected sealed override void UpdateMotionInput(MotionInput motionInput)
        {
            motionInput.MovementDirection.Set(0f, 0f, 0f);
            UpdateMotionInput(motionInput, _navMeshAgent);
        }

        //////////////////////////////
        ////////// Callback //////////

        /// <summary>
        /// Initialize the behaviour
        /// </summary>
        protected abstract void Initialize(ACharacterSystem characterSystem, MotionConfiguration motionConfiguration,
            NavMeshAgent navMeshAgent);
        
        /// <summary>
        /// Update the motion input in order to move the character
        /// </summary>
        protected abstract void UpdateMotionInput(MotionInput motionInput, NavMeshAgent navMeshAgent);
        
        //////////////////////////////
        ////////// Service ///////////
        
        /// <summary>
        /// Configure the NavMeshAgent
        /// </summary>
        private void SetupNavMeshAgent(ACharacterSystem characterSystem)
        {
            _navMeshAgent = characterSystem.GetComponent<NavMeshAgent>();
            _navMeshAgent.acceleration = 0.01f;
            _navMeshAgent.angularSpeed = 0.01f;
            _navMeshAgent.speed = 0.01f;
            _navMeshAgent.updatePosition = true;
            _navMeshAgent.updateRotation = false;
        }
    }
}
