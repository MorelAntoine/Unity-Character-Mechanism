using UniCraft.CharacterMechanism.System.Context.Environment;
using UniCraft.CharacterMechanism.System.Profile.Locomotion;
using UnityEngine;

namespace UniCraft.CharacterMechanism.System
{
    /// <inheritdoc/>
    /// <summary>
    /// Base module to manage the 3D components of a character
    /// </summary>
    public abstract class ACharacterSystem3D : ACharacterSystem
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////
        
        ///////////////////////////////
        ////////// Context ////////////

        [Header("Context")]
        [SerializeField] protected EnvironmentContext3D EnvironmentContext = null;

        ///////////////////////////////
        ////////// Profile ////////////

        [Header("Profile")]
        [SerializeField] protected LocomotionProfile3D LocomotionProfile = null;

        //////////////////////////////
        ////////// Property //////////
        //////////////////////////////

        ///////////////////////////////
        ////////// Context ////////////

        public EnvironmentContext3D GetEnvironmentContext => EnvironmentContext;

        ///////////////////////////////
        ////////// Profile ////////////

        public LocomotionProfile3D GetLocomotionProfile => LocomotionProfile;
    }
}
