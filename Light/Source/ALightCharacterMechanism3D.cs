/*
** ALightCharacterMechanism3D.cs for Unity-Character-Mechanism
**
** Made by Antoine MOREL
**
** Started on  Jan 05 2019 Antoine MOREL
** Last update Jan 09 2019 Antoine MOREL
** 
** Copyright (c) 2018 - 2019 All Rights Reserved
*/

using UnityEngine;

namespace CharacterMechanism.Light
{
    /// <inheritdoc/>
    /// <summary>
    /// Base class to create a light character mechanism 3D
    /// </summary>
    public abstract class ALightCharacterMechanism3D : ALightCharacterMechanism
    {
        ////////////////////////////
        ////////// Method //////////
        ////////////////////////////
        
        //////////////////////////////
        ////////// Callback //////////
        
        ////////// Collision //////////

        protected abstract void OnCollisionEnter(Collision other);

        protected abstract void OnCollisionStay(Collision other);

        protected abstract void OnCollisionExit(Collision other);

        protected abstract void OnParticleCollision(GameObject other);
        
        ////////// Trigger //////////

        protected abstract void OnTriggerEnter(Collider other);

        protected abstract void OnTriggerStay(Collider other);

        protected abstract void OnTriggerExit(Collider other);
    }
}