# Light Character Mechanism

The Light Character mechanism is an abstract class to inherit in order to create your own
character mechanism. The goal of this version is to provide a basic structure of code with
a low cost in memory and less code to maintain compared to the Normal version.

The Light Character Mechanism comes with five different types of mechanism, so be
sure to checkout which version fit your needs.

## Structure

ALightCharacterMechanism

    Generic version without collision and trigger detection
    
    If your character mechanism doesn't need the collision and the trigger detection,
    it's advised to use this type ; it'll reduce the processus cost.

ALightCharacterMechanism2D

    2D version with collision and trigger detection

ALightCharacterMechanism3D

    3D version with collision and trigger detection

ANavLightCharacterMechanism

    Generic version without collision and trigger detection, adapted for the use of a NavMesh

ANavLightCharacterMechanism3D

    3D version with collision and trigger detection, adapted for the use of a NavMesh

## Why use it

The Light Character Mechanism is made for low complex character mechanism ;
this means that if you have less than five action states, you should use it.

Example can be founded in the Example/ folder and Screenshots in the Screenshot/ folder.
