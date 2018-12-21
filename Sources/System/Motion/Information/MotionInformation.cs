using UnityEngine;

namespace UniCraft.CharacterMechanism.System.Motion.Information
{
    /// <summary>
    /// Class gathering all the information needed for a behaviour and a motion state machine
    /// </summary>
    [global::System.Serializable]
    public sealed class MotionInformation
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////

        [SerializeField] private MotionConfiguration _motionConfiguration = null;
        [SerializeField] private MotionInput _motionInput = null;

        //////////////////////////////
        ////////// Property //////////
        //////////////////////////////

        public MotionConfiguration GetMotionConfiguration => _motionConfiguration;
        public MotionInput GetMotionInput => _motionInput;
    }
}
