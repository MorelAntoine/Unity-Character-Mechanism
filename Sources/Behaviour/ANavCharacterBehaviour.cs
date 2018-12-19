using UnityEngine;
using UnityEngine.AI;

namespace UniCraft.CharacterMechanism.Behaviour
{
    /// <inheritdoc/>
    /// <summary>
    /// Base Module to create character behaviour that use NavMesh
    /// </summary>
    [RequireComponent(typeof(NavMeshAgent))]
    public abstract class ANavCharacterBehaviour : ACharacterBehaviour
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////

        protected NavMeshAgent NavMeshAgent = null;
        
        ////////////////////////////
        ////////// Method //////////
        ////////////////////////////

        //////////////////////////////
        ////////// Callback //////////
        
        protected override void Awake()
        {
            base.Awake();
            CharacterSystem.GetMotionInput.AdaptToNavMesh = true;
            NavMeshAgent = GetComponent<NavMeshAgent>();
            ConfigureNavMeshAgent();
        }
        
        /// <summary>
        /// Configure the NavMeshAgent
        /// </summary>
        protected virtual void ConfigureNavMeshAgent()
        {
            NavMeshAgent.acceleration = 8f;
            NavMeshAgent.speed = 1f;
            if ( NavMeshAgent.stoppingDistance < 0.1f )
            {
                NavMeshAgent.stoppingDistance = 1.2f;
            }
            NavMeshAgent.updatePosition = true;
            NavMeshAgent.updateRotation = false;
        }
    }
}
