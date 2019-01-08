using UnityEngine;

namespace CharacterMechanism.Light
{
    /// <inheritdoc/>
    /// <summary>
    /// Base class to create a light character mechanism 2D
    /// </summary>
    public abstract class ALightCharacterMechanism2D : ALightCharacterMechanism
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