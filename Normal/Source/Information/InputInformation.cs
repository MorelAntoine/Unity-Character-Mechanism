using CharacterMechanism.Normal.Information.Locomotion;
using System;
using UnityEngine;

namespace CharacterMechanism.Normal.Information
{
    /// <inheritdoc/>
    /// <summary>
    /// Class containing all the standard input information
    /// </summary>
    [Serializable]
    public sealed class InputInformation : IInformation
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////

        [SerializeField] private LocomotionInformation _locomotionInformation = null;
        
        //////////////////////////////
        ////////// Property //////////
        //////////////////////////////

        public LocomotionInformation GetLocomotionInformation => _locomotionInformation;

        ////////////////////////////
        ////////// Method //////////
        ////////////////////////////

        public void Reset()
        {
            _locomotionInformation.Reset();
        }
    }
}
