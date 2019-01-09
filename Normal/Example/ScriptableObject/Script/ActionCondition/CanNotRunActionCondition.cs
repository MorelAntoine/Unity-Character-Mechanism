/*
** CanNotRunActionCondition.cs for Unity-Character-Mechanism
**
** Made by Antoine MOREL
**
** Started on  Jan 07 2019 Antoine MOREL
** Last update Jan 09 2019 Antoine MOREL
** 
** Copyright (c) 2018 - 2019 All Rights Reserved
*/

using CharacterMechanism.Normal.Information;
using CharacterMechanism.Normal.ScriptableObject;
using UnityEngine;

namespace CharacterMechanism.Normal.Example
{
    /// <inheritdoc/>
    /// <summary>
    /// Example of action condition for a detection of not running
    /// </summary>
    [CreateAssetMenu(menuName = "CharacterMechanism/Example/ActionCondition/CanNotRun")]
    public sealed class CanNotRunActionCondition : AActionCondition
    {
        public override bool IsConditionFulfilled(InputInformation inputInformation)
        {
            return (!inputInformation.GetLocomotionInformation.ShouldRun);
        }
    }
}
