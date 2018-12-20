# Character Mechanism

Unity-Character-Mechanism is a framework aiming to facilitate the
code development of a character in Unity3D.

The framework use a custom version of the
Unity-Pluggable-Finite-State-Machine for the motion ; this meant that
condition, state and transition are assets and can be reusable
*(once it's coded, you don't have to do it again ; it's pretty useful)*.

**Space support**: 2D and 3D *(other space can be supported via
ACharacterSystem)*

**Motion support**: RootMotion and Script

**Supported features**: NavMesh

## Architecture

The framework is divided into three main parts : 

- **Behaviour**: Define the behaviour of the character. Focus on 
managing the inputs (AI or Player) in order to control the character.

- **System**: Gather all the required components of the character and
manage a motion state machine in order to move the character or trigger
actions on the character.

- **Motion *(Condition / State / Transition)***: Integrated in the
motion state machine, they define the requirements to transit to
another state *(Condition)*, they define the action and how it's behave
*(State)* and they define which state will be given after a transition
*(Transition)*.

## Tools

Behaviour

    - ACharacterBehaviour
        Base class to inherit in order to define a character behaviour.
        (e.g. Player)
    
    - ANavCharacterBehaviour
        Base class to inherit in order to define a character behaviour
        that use a NavMesh.
        (e.g. Follow AI)

System

    - ACharacterSystem
        Base class to inherit in order to define a character system.
    
    - ACharacterSystem2D
        Base class to inherit in order to define a character system 2D.
        (e.g. HumanSystem2D)
    
    - ACharacterSystem3D
        Base class to inherit in order to define a character system 3D.
        (e.g. HumanSystem3D)

Motion

    - AMotionCondition
        Base class to inherit in order to create a motion condition.
    
    - AMotionState
        Base class to inherit in order to create a motion state.
    
    - MotionTransition
        ScriptableObject to create motion transition.
        (nothing to inherit here, just create Asset)

System Extra Components

    - EnvironmentContext(2D or 3D)
        Allow you to get information between the character and the
        environment (e.g. IsGrounded)
    
    - LocomotionProfile(2D or 3D)
        If you don't use RootMotion, this profile define all the
        variables you need to move your character.

## Dependencies

**Unity-Attribute-Collection**: DisableInInspector
        
## Additional Information

Screenshots can be founded in the **Screenshots/** folder.

An example can be founded in the **Example/** folder.

Develop under Unity **2018.3.0b**

Version **2.0.0**

## Licence

MIT Licence