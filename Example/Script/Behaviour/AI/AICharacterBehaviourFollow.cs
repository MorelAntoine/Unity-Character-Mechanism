using UniCraft.CharacterMechanism.Behaviour;
using UniCraft.CharacterMechanism.System.Motion;
using UnityEngine;

namespace UniCraft.CharacterMechanism.Example.Behaviour.AI
{
    public sealed class AICharacterBehaviourFollow : ANavCharacterBehaviour
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////

        [SerializeField] private Transform _target = null;
        
        ////////////////////////////
        ////////// Method //////////
        ////////////////////////////
        
        protected override void Initialize(MotionInput mi)
        {}

        protected override void UpdateMotionInput(MotionInput mi)
        {
            if ( _target != null )
            {
                NavMeshAgent.destination = _target.position;
                mi.MovementDirection = NavMeshAgent.destination.normalized;
            }
        } 
    }
}
