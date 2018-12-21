using UniCraft.CharacterMechanism.System.Motion.Information;
using UniCraft.CharacterMechanism.System.Motion.StateMachine;
using UnityEngine;

namespace UniCraft.CharacterMechanism.System
{
    /// <inheritdoc/>
    /// <summary>
    /// Base module to manage the components of a character and a motion state machine
    /// </summary>
    [DisallowMultipleComponent]
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

        [SerializeField] private MotionInformation _motionInformation = null;
        [SerializeField] private MotionStateMachine _motionStateMachine = null;
        
        //////////////////////////////
        ////////// Property //////////
        //////////////////////////////
        
        //////////////////////////////
        ////////// Component //////////

        public Animator GetAnimator => Animator;
        
        ////////////////////////////
        ////////// Motion //////////
        
        ////////// Input //////////
        
        public MotionInformation GetMotionInformation => _motionInformation;
        
        ////////// State //////////
        
        public AMotionState GetCurrentState => _motionStateMachine.GetCurrentState;
        public AMotionState GetPreviousState => _motionStateMachine.GetPreviousState;
        
        ////////////////////////////
        ////////// Method //////////
        ////////////////////////////
        
        //////////////////////////////
        ////////// Callback //////////

        /// <summary>
        /// Initialize all the components
        /// </summary>
        protected abstract void InitializeComponents();
        
        /// <summary>
        /// Load all the required components
        /// </summary>
        protected virtual void LoadComponents()
        {
            Animator = GetComponent<Animator>();
        }
        
        ////////////////////////////////////////////
        ////////// MonoBehaviour Callback //////////

        protected virtual void Awake()
        {
            if ( !_motionStateMachine.Initialize() )
            {
                gameObject.SetActive(false);
            }
            else
            {
                LoadComponents();
                InitializeComponents();
            }
        }

        protected virtual void Start()
        {
            _motionStateMachine.Start(this);
        }
        
        protected virtual void FixedUpdate()
        {
            _motionStateMachine.Execute(_motionInformation);
        }

        protected virtual void Update()
        {
            _motionStateMachine.Update(this, _motionInformation);
        }
    }
}
