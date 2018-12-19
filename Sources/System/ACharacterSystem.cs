using UniCraft.CharacterMechanism.System.Motion;
using UniCraft.CharacterMechanism.System.Motion.FiniteStateMachine;
using UnityEngine;

namespace UniCraft.CharacterMechanism.System
{
    /// <inheritdoc/>
    /// <summary>
    /// Base Module to create a character system
    /// </summary>
    public abstract class ACharacterSystem : MonoBehaviour
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////
        
        ///////////////////////////////
        ////////// Component //////////

        [SerializeField] protected Animator Animator = null;

        ////////////////////////////
        ////////// Motion //////////

        [SerializeField] protected MotionInput MotionInput = null;
        [SerializeField] protected MotionStateMachine MotionStateMachine = null;
        
        //////////////////////////////
        ////////// Property //////////
        //////////////////////////////
        
        //////////////////////////////
        ////////// Component //////////

        public Animator GetAnimator => Animator;
        
        ////////////////////////////
        ////////// Motion //////////
        
        public MotionInput GetMotionInput => MotionInput;
        
        ////////////////////////////
        ////////// Method //////////
        ////////////////////////////
        
        //////////////////////////////
        ////////// Callback //////////

        /// <summary>
        /// Initialize all the components of the character
        /// </summary>
        protected virtual void InitializeComponents()
        {
            Animator = GetComponent<Animator>();
        }
        
        ////////////////////////////////////////////
        ////////// MonoBehaviour Callback //////////

        protected virtual void Awake()
        {
            InitializeComponents();
            MotionStateMachine.Initialize();
        }

        protected virtual void FixedUpdate()
        {
            MotionStateMachine.Execute(this, MotionInput);
        }

        protected virtual void Update()
        {
            MotionStateMachine.UpdateCurrentState(this, MotionInput);
        }
        
    }
}
