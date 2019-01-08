using CharacterMechanism.Normal.Mechanism;
using UnityEngine;

namespace CharacterMechanism.Normal.Example
{
    /// <inheritdoc/>
    /// <summary>
    /// Example of base character mechanism using the generic character mechanism
    /// </summary>
    /// <remarks>
    /// ACharacterMechanism is used because the script doesn't need collision and trigger detection
    /// </remarks>
    [RequireComponent(typeof(Rigidbody))]
    public abstract class AExampleCharacterMechanism : ACharacterMechanism
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////
    
        ///////////////////////////////
        ////////// Component //////////

        private Rigidbody _rigidbody = null;
        
        /////////////////////////////
        ////////// Profile //////////

        [Header("Profile")]
        [SerializeField] private LocomotionProfile _locomotionProfile = null;
        
        //////////////////////////////
        ////////// Property //////////
        //////////////////////////////

        ///////////////////////////////
        ////////// Component //////////
        
        public Rigidbody GetRigidbody => _rigidbody;

        /////////////////////////////
        ////////// Profile //////////
        
        public LocomotionProfile GetLocomotionProfile => _locomotionProfile;
        
        ////////////////////////////
        ////////// Method //////////
        ////////////////////////////
    
        //////////////////////////////
        ////////// Callback //////////

        ////////// Component //////////

        protected override void InitializeComponents()
        {
            _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        }

        protected override void LoadComponents()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
    }
}
