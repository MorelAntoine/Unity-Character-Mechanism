using UniCraft.CharacterMechanism.System.Context.Environment;
using UniCraft.CharacterMechanism.System.Profile.Locomotion;
using UnityEngine;

namespace UniCraft.CharacterMechanism.System
{
    /// <inheritdoc/>
    /// <summary>
    /// Base module to manage the 2D components of the character
    /// </summary>
    public abstract class ACharacterSystem2D : ACharacterSystem
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////

        ///////////////////////////////
        ////////// Component //////////

        [SerializeField] protected Collider2D Collider = null;
        [SerializeField] protected Rigidbody2D Rigidbody = null;
        
        ///////////////////////////////
        ////////// Context ////////////

        [SerializeField] protected EnvironmentContext2D EnvironmentContext = null;

        ///////////////////////////////
        ////////// Profile ////////////

        [SerializeField] protected LocomotionProfile2D LocomotionProfile = null;

        //////////////////////////////
        ////////// Property //////////
        //////////////////////////////

        ///////////////////////////////
        ////////// Component //////////

        public Collider2D GetCollider => Collider;
        public Rigidbody2D GetRigidbody => Rigidbody;
        
        ///////////////////////////////
        ////////// Context ////////////

        public EnvironmentContext2D GetEnvironmentContext => EnvironmentContext;

        ///////////////////////////////
        ////////// Profile ////////////

        public LocomotionProfile2D GetLocomotionProfile => LocomotionProfile;
        
        ////////////////////////////
        ////////// Method //////////
        ////////////////////////////

        protected override void InitializeComponents()
        {
        }

        protected override void LoadComponents()
        {
            base.LoadComponents();
            Collider = GetComponent<Collider2D>();
            Rigidbody = GetComponent<Rigidbody2D>();
        }
    }
}
