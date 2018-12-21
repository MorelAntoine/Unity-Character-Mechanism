using UniCraft.AttributeCollection;
using UnityEngine;

namespace UniCraft.CharacterMechanism.System.Motion.Information
{
    /// <summary>
    /// Class containing all the input information required for a behaviour and a motion state machine
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
        /// <remarks>Call before every UpdateMotionInput</remarks>
        /// </summary>
        public void Reset()
        {
            MovementDirection.Set(0f, 0f, 0f);
        }
    }
}
