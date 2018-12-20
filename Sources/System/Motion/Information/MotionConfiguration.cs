using UniCraft.AttributeCollection;

namespace UniCraft.CharacterMechanism.System.Motion.Information
{
    /// <summary>
    /// Class to contain configuration about motion for the motion state machine
    /// </summary>
    [global::System.Serializable]
    public sealed class MotionConfiguration
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////
        
        [DisableInInspector] public bool AdaptToNavMesh = false;
    }
}
