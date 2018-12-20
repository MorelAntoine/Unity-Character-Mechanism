﻿using UniCraft.CharacterMechanism.Behaviour;
using UniCraft.CharacterMechanism.System.Motion;
using UnityEngine;

namespace UniCraft.CharacterMechanism.Example.Behaviour.Player
{
    public class CharacterPlayerBehaviour2D : ACharacterBehaviour
    {
        protected override void Initialize(MotionInput mi)
        {
        }

        protected override void UpdateMotionInput(MotionInput mi)
        {
            mi.MovementDirection.Set(Input.GetAxisRaw("Horizontal"), 0f, 0f);
        }
    }
}
