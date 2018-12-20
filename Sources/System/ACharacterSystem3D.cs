using UniCraft.CharacterMechanism.System.Context.Environment;
using UniCraft.CharacterMechanism.System.Profile.Locomotion;
using UnityEngine;

namespace UniCraft.CharacterMechanism.System
{
    /// <inheritdoc/>
    /// <summary>
    /// Base module to manage the 3D components of the character
    /// </summary>
    public abstract class ACharacterSystem3D : ACharacterSystem
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////

        ///////////////////////////////
        ////////// Component //////////

        [SerializeField] protected Collider Collider = null;
        [SerializeField] protected Rigidbody Rigidbody = null;
        
        ///////////////////////////////
        ////////// Context ////////////

        [SerializeField] protected EnvironmentContext3D EnvironmentContext = null;

        ///////////////////////////////
        ////////// Profile ////////////

        [SerializeField] protected LocomotionProfile3D LocomotionProfile = null;

        //////////////////////////////
        ////////// Property //////////
        //////////////////////////////

        ///////////////////////////////
        ////////// Component //////////

        public Collider GetCollider => Collider;
        public Rigidbody GetRigidbody => Rigidbody;
        
        ///////////////////////////////
        ////////// Context ////////////

        public EnvironmentContext3D GetEnvironmentContext => EnvironmentContext;

        ///////////////////////////////
        ////////// Profile ////////////

        public LocomotionProfile3D GetLocomotionProfile => LocomotionProfile;
        
        ////////////////////////////
        ////////// Method //////////
        ////////////////////////////

        protected override void InitializeComponents()
        {
        }

        protected override void LoadComponents()
        {
            base.LoadComponents();
            Collider = GetComponent<Collider>();
            Rigidbody = GetComponent<Rigidbody>();
        }
    }
}
