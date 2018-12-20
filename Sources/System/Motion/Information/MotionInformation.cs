using UnityEngine;

namespace UniCraft.CharacterMechanism.System.Motion.Information
{
    /// <summary>
    /// Class to gather all the information about motion for a motion state machine
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
