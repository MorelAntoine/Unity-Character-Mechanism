/*
** AActionState.cs for Unity-Character-Mechanism
**
** Made by Antoine MOREL
**
** Started on  Jan 06 2019 Antoine MOREL
** Last update Jan 09 2019 Antoine MOREL
** 
** Copyright (c) 2018 - 2019 All Rights Reserved
*/

using CharacterMechanism.Normal.Information;
using CharacterMechanism.Normal.System;
using UnityEngine;

namespace CharacterMechanism.Normal.ScriptableObject
{
    /// <inheritdoc/>
    /// <summary>
    /// Base class to create an action state
    /// </summary>
    public abstract class AActionState : UnityEngine.ScriptableObject
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////

        [SerializeField] private ActionTransition[] _actionTransitions = null;
        
        ////////////////////////////
        ////////// Method //////////
        ////////////////////////////
        
        /////////////////////////
        ////////// API //////////

        /// <summary>
        /// Attempt to return the next action state
        /// </summary>
        public AActionState AttemptToGetNextActionState(InputInformation inputInformation)
        {
            foreach ( var actionTransition in _actionTransitions )
            {
                var nextActionState = actionTransition.Simulate(inputInformation);
                
                if ( nextActionState )
                {
                    return (nextActionState);
                }
            }
            return (null);
        }
        
        //////////////////////////////
        ////////// Callback //////////
        
        /// <summary>
        /// Launch the action
        /// </summary>
        /// <remarks>
        /// Call when the action state is loaded
        /// </remarks>
        public abstract void BeginAction(ACharacterSystem characterSystem, InputInformation inputInformation);

        /// <summary>
        /// Close the action
        /// </summary>
        /// <remarks>
        /// Call when the action state is changed
        /// </remarks>
        public abstract void EndAction(ACharacterSystem characterSystem, InputInformation inputInformation);

        /// <summary>
        /// Update the action
        /// </summary>
        /// <remarks>
        /// Call every FixedUpdate
        /// </remarks>
        public abstract void UpdateAction(ACharacterSystem characterSystem, InputInformation inputInformation);
    }
}
