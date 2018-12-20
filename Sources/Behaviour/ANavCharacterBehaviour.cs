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
            _navMeshAgent.acceleration = 8f;
            _navMeshAgent.speed = 1f;
            if ( _navMeshAgent.stoppingDistance < 0.1f )
            {
                _navMeshAgent.stoppingDistance = 1.2f;
            }
            _navMeshAgent.updatePosition = true;
            _navMeshAgent.updateRotation = false;
        }
    }
}
