/*
** RunActionState.cs for Unity-Character-Mechanism
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
using CharacterMechanism.Normal.System;
using UnityEngine;

namespace CharacterMechanism.Normal.Example
{
    /// <inheritdoc/>
    /// <summary>
    /// Example of run action state 
    /// </summary>
    [CreateAssetMenu(menuName = "CharacterMechanism/Example/ActionState/Run")]
    public sealed class RunActionState : AActionState
    {
        public override void BeginAction(ACharacterSystem characterSystem, InputInformation inputInformation)
        {}

        public override void EndAction(ACharacterSystem characterSystem, InputInformation inputInformation)
        {}

        public override void UpdateAction(ACharacterSystem characterSystem, InputInformation inputInformation)
        {
            var human = characterSystem as HumanSystem;

            human.transform.Rotate(0f
                , inputInformation.GetLocomotionInformation.MovementDirection.x * human.GetLocomotionProfile.AngularSpeed * Time.deltaTime
                , 0f, Space.Self);
            human.transform.Translate(0f, 0f,
                inputInformation.GetLocomotionInformation.MovementDirection.z * human.GetLocomotionProfile.RunSpeed * Time.deltaTime,
                Space.Self);
        }
    }
}
