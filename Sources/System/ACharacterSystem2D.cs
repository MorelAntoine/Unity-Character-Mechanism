using UniCraft.CharacterMechanism.System.Context.Environment;
using UniCraft.CharacterMechanism.System.Profile.Locomotion;
using UnityEngine;

namespace UniCraft.CharacterMechanism.System
{
    /// <inheritdoc/>
    /// <summary>
    /// Base Module to create a 2D character system
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
            base.InitializeComponents();
            Collider = GetComponent<Collider2D>();
            Rigidbody = GetComponent<Rigidbody2D>();
        }
    }
}
