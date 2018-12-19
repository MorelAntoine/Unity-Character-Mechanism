using UnityEngine;

namespace UniCraft.CharacterMechanism.System.Profile.Locomotion
{
    /// <summary>
    /// Profile to store all the 2D locomotion settings
    /// </summary>
    [global::System.Serializable]
    public sealed class LocomotionProfile2D
    {
        [Range(1f, 6f)] public float WalkSpeed = 2f;
    }
}
