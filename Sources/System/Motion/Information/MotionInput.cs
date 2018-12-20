using UniCraft.AttributeCollection;
using UnityEngine;

namespace UniCraft.CharacterMechanism.System.Motion.Information
{
    /// <summary>
    /// Class to contain the input information for the motion state machine and the behaviour
    /// </summary>
    [global::System.Serializable]
    public sealed class MotionInput
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////
        
        [DisableInInspector] public Vector3 MovementDirection = Vector3.zero;
        
        ////////////////////////////
        ////////// Method //////////
        ////////////////////////////

        /// <summary>
        /// Reset all the input information
        /// </summary>
        public void Reset()
        {
            MovementDirection.Set(0f, 0f, 0f);
        }
    }
}
