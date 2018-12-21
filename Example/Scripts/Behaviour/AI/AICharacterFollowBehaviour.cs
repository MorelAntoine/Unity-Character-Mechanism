using UniCraft.CharacterMechanism.Behaviour;
using UniCraft.CharacterMechanism.System;
using UniCraft.CharacterMechanism.System.Motion.Information;
using UnityEngine;
using UnityEngine.AI;

namespace UniCraft.CharacterMechanism.Example.Behaviour
{
    /// <inheritdoc/>
    /// <summary>
    /// Basic AI Follower that use the NavMesh
    /// </summary>
    public class AICharacterFollowBehaviour : ANavCharacterBehaviour
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////

        [SerializeField] private Transform _target = null;
        private Vector3 _destination;
        
        ////////////////////////////
        ////////// Method //////////
        ////////////////////////////

        /////////////////////////////////////////////////////
        ////////// ANavCharacterBehaviour Callback //////////
        
        protected override void Initialize(ACharacterSystem characterSystem, MotionConfiguration motionConfiguration,
            NavMeshAgent navMeshAgent)
        {
            UpdateDestination(navMeshAgent);
        }

        protected override void UpdateMotionInput(MotionInput motionInput, NavMeshAgent navMeshAgent)
        {
            if ( Vector3.Distance(_destination, _target.position) > navMeshAgent.stoppingDistance )
            {
                UpdateDestination(navMeshAgent);
            }
            if ( !IsArrived )
            {
                motionInput.MovementDirection = GetNextDirection;
            }
        }
        
        /////////////////////////////
        ////////// Service //////////

        private void UpdateDestination(NavMeshAgent navMeshAgent)
        {
            _destination = _target.position;
            navMeshAgent.SetDestination(_destination);
        }
    }
}
