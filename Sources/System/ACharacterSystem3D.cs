using UniCraft.CharacterMechanism.System.Context.Environment;
using UniCraft.CharacterMechanism.System.Profile.Locomotion;
using UnityEngine;

namespace UniCraft.CharacterMechanism.System
{
    /// <inheritdoc/>
    /// <summary>
    /// Base Module to create a 3D character system
    /// </summary>
    public abstract class ACharacterSystem3D : ACharacterSystem
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////

        ///////////////////////////////
        ////////// Component //////////

        [SerializeField] protected Collider Collider;
        [SerializeField] protected Rigidbody Rigidbody;
        
        ///////////////////////////////
        ////////// Context ////////////

        [SerializeField] protected EnvironmentContext3D EnvironmentContext;

        ///////////////////////////////
        ////////// Profile ////////////

        [SerializeField] protected LocomotionProfile3D LocomotionProfile;

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
            base.InitializeComponents();
            Collider = GetComponent<Collider>();
            Rigidbody = GetComponent<Rigidbody>();
        }
    }
}
