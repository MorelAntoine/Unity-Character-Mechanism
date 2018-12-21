using UniCraft.CharacterMechanism.System.Context.Environment;
using UniCraft.CharacterMechanism.System.Profile.Locomotion;
using UnityEngine;

namespace UniCraft.CharacterMechanism.System
{
    /// <inheritdoc/>
    /// <summary>
    /// Base module to manage the 2D components of a character
    /// </summary>
    public abstract class ACharacterSystem2D : ACharacterSystem
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////
        
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
        ////////// Context ////////////

        public EnvironmentContext2D GetEnvironmentContext => EnvironmentContext;

        ///////////////////////////////
        ////////// Profile ////////////

        public LocomotionProfile2D GetLocomotionProfile => LocomotionProfile;
    }
}
