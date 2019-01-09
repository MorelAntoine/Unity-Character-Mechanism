/*
** InputInformation.cs for Unity-Character-Mechanism
**
** Made by Antoine MOREL
**
** Started on  Jan 08 2019 Antoine MOREL
** Last update Jan 09 2019 Antoine MOREL
** 
** Copyright (c) 2018 - 2019 All Rights Reserved
*/

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
