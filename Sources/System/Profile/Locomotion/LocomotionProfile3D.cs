using UnityEngine;

namespace UniCraft.CharacterMechanism.System.Profile.Locomotion
{
    /// <summary>
    /// Profile to store all the 3D locomotion settings
    /// </summary>
    [global::System.Serializable]
    public sealed class LocomotionProfile3D
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////
        
        [Range(90f, 130)] public float AngularSpeed = 120f;
        [Range(140f, 180f)] public float AngularSpeedStationary = 160f;
        [Range(1f, 6f)] public float WalkSpeed = 2f;
        
        ////////////////////////////
        ////////// Method //////////
        ////////////////////////////

        /// <summary>
        /// Return the right amount of angular speed between AngularSpeedStationary and AngularSpeed 
        /// </summary>
        public float InterpolateAngularSpeed(float coefficient)
        {
            return (Mathf.Lerp(AngularSpeedStationary, AngularSpeed, coefficient));
        }
    }
}
