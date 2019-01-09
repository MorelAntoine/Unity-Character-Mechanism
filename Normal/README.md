# Normal Character Mechanism

The Normal Character Mechanism is an abstract class to inherit in order to create your own
character mechanism. The goal of this version is to provide a basic structure of code with
reusable conditions, states and transitions ; and standardize all the input information.

All the sections of the code development of a character is divided into single part in order to
offer the most scalable, maintainable and reusable code. 

It's important to note that **condition, state and transition are single instance shared by all the
character mechanism** ; this means that no matter the number of Normal Character Mechanism you have
only there mechanism will be instantiated, so the memory cost is highly reduced. 

The Normal Character Mechanism comes with five different types of mechanism, so be
sure to checkout which version fit your needs.

## Structure

ACharacterMechanism

    Generic version without collision and trigger detection
    
    If your character mechanism doesn't need the collision and the trigger detection,
    it's advised to use this type ; it'll reduce the processus cost.

ACharacterMechanism2D

    2D version with collision and trigger detection

ACharacterMechanism3D

    3D version with collision and trigger detection

ANavCharacterMechanism

    Generic version without collision and trigger detection, adapted for the use of a NavMesh

ANavCharacterMechanism3D

    3D version with collision and trigger detection, adapted for the use of a NavMesh

## ScriptableObject

**AActionCondition**

Action condition are scriptable object used to define the requirements in order to transit to another action state.

It's important to note that action condition only use Input Information as data.

    Abstract class to inherit to create an action condition
    
    Don't forget to add [CreateAssetMenu(menuName = "YourPathToActionCondition")] above your class in order to create you action condition

**AActionState**

Action state are scriptable object used to define the behaviour of your character during a state.

    Abstract class to inherit to create an action state

    Don't forget to add [CreateAssetMenu(menuName = "YourPathToActionState")] above your class in order to create you action state

**ActionTransition**

Action transition are scriptable object used to define which action state require which action conditions in order to be effective

    ScriptableObject used to create action transition
    
    **Right Click -> Create -> CharacterMechanism -> ScriptableObject -> ActionTransition**

## Input Information

Standardized information used to control action conditions and action states in a generic way.

If you want to create your own information class, implement IInformation and add your
class as attribute *(with get property and reset method)* to the Input Information class.

*For example, in order to move a player you might use Input.GetAxis to get information about which
direction to take but an AI that use a NavMeshAgent won't use Input.GetAxis ; that why a 
standardized input information need to be provided in order to produce reusable and generic
action condition and generic action state.*

## Why use it

The Normal Character Mechanism is advised to be used when you have multiple character mechanism
that use the same condition, state or transition ; or when you have more than four
action states.

Example can be founded in the Example/ folder and screenshots in the Screenshot/ folder.