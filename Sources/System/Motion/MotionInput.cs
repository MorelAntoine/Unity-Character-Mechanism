using UniCraft.AttributeCollection;
using UnityEngine;

namespace UniCraft.CharacterMechanism.System.Motion
{
    /// <summary>
    /// Class to manage motion input in order to control the character
    /// </summary>
    [global::System.Serializable]
    public sealed class MotionInput
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////

        ///////////////////////////////////
        ////////// Configuration //////////

        [Header("Configuration")]
        [DisableInInspector] public bool AdaptToNavMesh = false;
        
        /////////////////////////////////
        ////////// Information //////////
        
        [Header("Information")]
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
