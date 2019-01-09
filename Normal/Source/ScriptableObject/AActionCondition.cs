/*
** AActionCondition.cs for Unity-Character-Mechanism
**
** Made by Antoine MOREL
**
** Started on  Jan 06 2019 Antoine MOREL
** Last update Jan 09 2019 Antoine MOREL
** 
** Copyright (c) 2018 - 2019 All Rights Reserved
*/

using CharacterMechanism.Normal.Information;

namespace CharacterMechanism.Normal.ScriptableObject
{
    /// <inheritdoc/>
    /// <summary>
    /// Base class to create an action condition
    /// </summary>
    public abstract class AActionCondition : UnityEngine.ScriptableObject
    {
        /// <summary>
        /// Verify is the action condition is fulfilled
        /// </summary>
        public abstract bool IsConditionFulfilled(InputInformation inputInformation);
    }
}
