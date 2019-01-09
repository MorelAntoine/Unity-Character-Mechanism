using CharacterMechanism.Normal.Behaviour;
using CharacterMechanism.Normal.Information;
using UnityEngine;

namespace CharacterMechanism.Normal.Example
{
    /// <inheritdoc/>
    /// <summary>
    /// Example of player behaviour using the generic character behaviour
    /// </summary>
    /// <remarks>
    /// ACharacterBehaviour is used because the script doesn't need collision and trigger detection
    /// </remarks>
    public sealed class PlayerBehaviour : ACharacterBehaviour
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////

        [Header("Input Setting")]
        [SerializeField] private KeyCode _jumpKeyCode = KeyCode.Space;
        [SerializeField] private KeyCode _runKeyCode = KeyCode.LeftShift;
                
        ////////////////////////////
        ////////// Method //////////
        ////////////////////////////
    
        //////////////////////////////
        ////////// Callback //////////
        
        ////////// Activation //////////
        
        protected override void OnDestroy()
        {}

        protected override void OnDisable()
        {}

        protected override void OnEnable()
        {}

        ////////// Input Information //////////
        
        protected override void InitializeInformation()
        {}

        protected override void LoadInformationComponents()
        {}
        
        protected override void OverrideInputInformationReset(InputInformation inputInformation)
        {}

        protected override void UpdateInputInformation(InputInformation inputInformation)
        {
            inputInformation.GetLocomotionInformation.ShouldJump = Input.GetKeyDown(_jumpKeyCode);
            inputInformation.GetLocomotionInformation.ShouldRun = Input.GetKey(_runKeyCode);
            inputInformation.GetLocomotionInformation.MovementDirection
                .Set(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        }
    }
}
