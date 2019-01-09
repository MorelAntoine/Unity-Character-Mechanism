/*
** ACharacterBehaviour2D.cs for Unity-Character-Mechanism
**
** Made by Antoine MOREL
**
** Started on  Jan 09 2019 Antoine MOREL
** Last update Jan 09 2019 Antoine MOREL
** 
** Copyright (c) 2018 - 2019 All Rights Reserved
*/

using UnityEngine;

namespace CharacterMechanism.Normal.Behaviour
{
    /// <inheritdoc/>
    /// <summary>
    /// Base class to create a character behaviour 2D
    /// </summary>
    public abstract class ACharacterBehaviour2D : ACharacterBehaviour
    {
        ////////////////////////////
        ////////// Method //////////
        ////////////////////////////
        
        //////////////////////////////
        ////////// Callback //////////
        
        ////////// Collision //////////

        protected abstract void OnCollisionEnter2D(Collision2D other);

        protected abstract void OnCollisionStay2D(Collision2D other);

        protected abstract void OnCollisionExit2D(Collision2D other);

        protected abstract void OnParticleCollision(GameObject other);
        
        ////////// Trigger //////////

        protected abstract void OnTriggerEnter2D(Collider2D other);

        protected abstract void OnTriggerStay2D(Collider2D other);

        protected abstract void OnTriggerExit2D(Collider2D other);
    }
}