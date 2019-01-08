using UnityEngine;

namespace CharacterMechanism.Normal.Mechanism
{
    /// <inheritdoc/>
    /// <summary>
    /// Base class to create a character mechanism 2D
    /// </summary>
    public abstract class ACharacterMechanism2D : ACharacterMechanism
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