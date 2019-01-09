# Normal Character Mechanism

The Normal Character Mechanism are abstract class to inherit *(Behaviour and System)* in order to
create your own character mechanism. The goal of this version is to provide a basic structure of
code with reusable conditions, states, transitions and systems ; and standardize all the input
information.

All the sections of the code development of a character is divided into single part in order to
offer the most scalable, maintainable and reusable code. 

It's important to note that **condition, state and transition are single instance shared by all the
character mechanism** ; this means that no matter the number of Normal Character Mechanism you have
only there mechanism will be instantiated, so the memory cost is highly reduced.

The Normal Character Mechanism comes with five different types of behaviour, so be
sure to checkout which version fit your needs.

## Behaviour

Allow you to define the control of your character.

ACharacterBehaviour

    Generic version without collision and trigger detection
    
    If your character behaviour doesn't need the collision and the trigger detection,
    it's advised to use this type ; it'll reduce the processus cost.

ACharacterBehaviour2D

    2D version with collision and trigger detection

ACharacterBehaviour3D

    3D version with collision and trigger detection

ANavCharacterBehaviour

    Generic version without collision and trigger detection, adapted for the use of a NavMesh

ANavCharacterBehaviour3D

    3D version with collision and trigger detection, adapted for the use of a NavMesh

If you want to create a character behaviour you must inherit from one of the base behaviours.

## System

Allow you to group all the components and settings you need to drive your character.
Behind the scene, the system manage the action states and action transitions.

ACharacterSystem

    Generic system without component

If you want to create a character system you must inherit from ACharacterSystem.

## ScriptableObject

**AActionCondition**

Action condition are scriptable object used to define the requirements in order to transit to another action state.

It's important to note that action condition only use Input Information as data.

    Abstract class to inherit to create an action condition
    
    Don't forget to add [CreateAssetMenu(menuName = "YourPathToActionCondition")] above your class in order to create you action condition

**AActionState**

Action state are scriptable object used to define an action for your character.

    Abstract class to inherit to create an action state

    Don't forget to add [CreateAssetMenu(menuName = "YourPathToActionState")] above your class in order to create you action state

**ActionTransition**

Action transition are scriptable object used to define which action state require which action conditions in order to be effective

    ScriptableObject used to create action transition
    
    **Right Click -> Create -> CharacterMechanism -> ScriptableObject -> ActionTransition**

## Input Information

Standardized information used to control action conditions and action states in a generic way.

If you want to create your own information class, implement **IInformation** and add your
class as attribute *(with get property and reset method)* to the Input Information class.

*For example, in order to move a player you might use Input.GetAxis to get information about which
direction to take but an AI that use a NavMeshAgent won't use Input.GetAxis ; that why a 
standardized input information need to be provided in order to produce reusable and generic
action condition and generic action state.*

## Why use it

The Normal Character Mechanism is advised to be used when you have multiple duplicated conditions,
states, transitions or systems ; or when you have more than four
action states.

Example can be founded in the Example/ folder and screenshots in the Screenshot/ folder.