/*
** LightPlayerMechanism.cs for Unity-Character-Mechanism
**
** Made by Antoine MOREL
**
** Started on  Jan 05 2019 Antoine MOREL
** Last update Jan 09 2019 Antoine MOREL
** 
** Copyright (c) 2018 - 2019 All Rights Reserved
*/

using CharacterMechanism.Normal.Attribute;
using UnityEngine;

namespace CharacterMechanism.Light.Example
{
    /// <inheritdoc/>
    /// <summary>
    /// Example of player mechanism using the generic light character mechanism
    /// </summary>
    /// <remarks>
    /// ALightCharacterMechanism is used because the script doesn't need collision and trigger detection
    /// </remarks>
    [RequireComponent(typeof(Rigidbody))]
    public sealed class LightPlayerMechanism : ALightCharacterMechanism
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////
    
        ///////////////////////////////
        ////////// Component //////////

        private Rigidbody _rigidbody = null;
        
        ///////////////////////////////////////
        ////////// Input Information //////////

        [Header("Input Information")]
        [ReadOnly, SerializeField] private Vector3 _movementDirection = Vector3.zero;
        [ReadOnly, SerializeField] private bool _shouldJump = false;
        [ReadOnly, SerializeField] private bool _shouldRun = false;
        
        ///////////////////////////////////
        ////////// Input Setting //////////

        [Header("Input Setting")]
        [SerializeField] private KeyCode _jumpKeyCode = KeyCode.Space;
        [SerializeField] private KeyCode _runKeyCode = KeyCode.LeftShift;
        
        ////////////////////////////////////////
        ////////// Locomotion Setting //////////

        [Header("Locomotion Setting")]
        [SerializeField, Range(80f, 160f)] private float _angularSpeed = 140f;
        [SerializeField, Range(2f, 8f)] private float _jumpForce = 4f;
        [SerializeField, Range(5f, 20f)] private float _runSpeed = 8f;
        [SerializeField, Range(1f, 4f)] private float _walkSpeed = 2f;
        
        ////////////////////////////
        ////////// Method //////////
        ////////////////////////////
    
        //////////////////////////////
        ////////// Callback //////////
    
        ////////// Action //////////
    
        protected override void BeginAction()
        {}

        protected override void UpdateAction()
        {
            if ( _shouldJump )
            {
                Jump();
            }

            if ( _movementDirection == Vector3.zero )
            {
                Idle();
            }
            else
            {
                if ( _shouldRun )
                {
                    Run();
                }
                else
                {
                    Walk();
                }
            }
        }
    
        ////////// Activation //////////

        protected override void OnDestroy()
        {}
        
        protected override void OnDisable()
        {}
        
        protected override void OnEnable()
        {}

        ////////// Component //////////

        protected override void InitializeComponents()
        {
            _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        }
        
        protected override void LoadComponents()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        ////////// Input Information //////////

        protected override void ResetInputInformation()
        {
            _shouldJump = false;
            _shouldRun = false;
            _movementDirection.Set(0f, 0f, 0f);
        }

        protected override void UpdateInputInformation()
        {
            _shouldJump = Input.GetKeyDown(_jumpKeyCode);
            _shouldRun = Input.GetKey(_runKeyCode);
            _movementDirection.Set(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        }
    
        //////////////////////////////////
        ////////// State Action //////////

        private void Idle()
        {}

        private void Jump()
        {
            _rigidbody.AddForce(0f, _jumpForce, 0f, ForceMode.Impulse);
        }

        private void Run()
        {
            transform.Rotate(0f, _movementDirection.x * _angularSpeed * Time.deltaTime, 0f, Space.Self);
            transform.Translate(0f, 0f, _movementDirection.z * _runSpeed * Time.deltaTime, Space.Self);
        }

        private void Walk()
        {
            transform.Rotate(0f, _movementDirection.x * _angularSpeed * Time.deltaTime, 0f, Space.Self);
            transform.Translate(0f, 0f, _movementDirection.z * _walkSpeed * Time.deltaTime, Space.Self);
        }
    }
}
