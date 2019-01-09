/*
** ANavCharacterBehaviour.cs for Unity-Character-Mechanism
**
** Made by Antoine MOREL
**
** Started on  Jan 09 2019 Antoine MOREL
** Last update Jan 09 2019 Antoine MOREL
** 
** Copyright (c) 2018 - 2019 All Rights Reserved
*/

using UnityEngine;
using UnityEngine.AI;

namespace CharacterMechanism.Normal.Behaviour
{
    /// <inheritdoc/>
    /// <summary>
    /// Base class to create a generic nav character behaviour
    /// </summary>
    [RequireComponent(typeof(NavMeshAgent))]
    public abstract class ANavCharacterBehaviour : ACharacterBehaviour
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
        /// Call at the beginning after InitializeInformationComponents
        /// </remarks>
        protected virtual void ConfigureNavMeshAgent()
        {
            _NavMeshAgent.acceleration = 0.01f;
            _NavMeshAgent.angularSpeed = 0.01f;
            _NavMeshAgent.speed = 0.01f;
            _NavMeshAgent.stoppingDistance = 0.8f;
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