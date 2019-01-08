using UnityEngine;

namespace CharacterMechanism.Normal.Mechanism
{
    /// <inheritdoc/>
    /// <summary>
    /// Base class to create a character mechanism 3D
    /// </summary>
    public abstract class ACharacterMechanism3D : ACharacterMechanism
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
