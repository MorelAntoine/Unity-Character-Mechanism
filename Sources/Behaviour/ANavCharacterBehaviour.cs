using UniCraft.CharacterMechanism.System;
using UniCraft.CharacterMechanism.System.Motion.Information;
using UnityEngine;
using UnityEngine.AI;

namespace UniCraft.CharacterMechanism.Behaviour
{
    /// <inheritdoc/>
    /// <summary>
    /// Base module to define a behaviour for a character that use a NavMesh
    /// </summary>
    [RequireComponent(typeof(NavMeshAgent))]
    public abstract class ANavCharacterBehaviour : ACharacterBehaviour
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////

        private ACharacterSystem _acs = null; // _characterSystem is already used by ACharacterBehaviour,
                                              // multiple definitions lead to compilation errors
        private NavMeshAgent _navMeshAgent = null;
        
        //////////////////////////////
        ////////// Property //////////
        //////////////////////////////

        /// <summary>
        /// Normalize and convert to local space the next direction
        /// </summary>
        protected Vector3 GetNextDirection => _acs.transform
            .InverseTransformDirection(_navMeshAgent.desiredVelocity.normalized);
        
        /// <summary>
        /// Verify if the agent is arrived to the destination or not
        /// </summary>
        protected bool IsArrived => (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance);
        
        ////////////////////////////
        ////////// Method //////////
        ////////////////////////////

        //////////////////////////////////////////////////
        ////////// ACharacterBehaviour Callback //////////

        protected sealed override void Initialize(ACharacterSystem characterSystem,
            MotionConfiguration motionConfiguration)
        {
            _acs = characterSystem;
            _navMeshAgent = _acs.GetComponent<NavMeshAgent>();
            ConfigureNavMeshAgent();
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
        /// <code>The NavMeshAgent need to have a minimum speed value in order to move</code>
        /// </summary>
        private void ConfigureNavMeshAgent()
        {
            _navMeshAgent.acceleration = 0.01f;
            _navMeshAgent.angularSpeed = 0.01f;
            _navMeshAgent.speed = 0.01f;
            _navMeshAgent.updatePosition = true;
            _navMeshAgent.updateRotation = false;
        }
    }
}
