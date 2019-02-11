# Character Mechanism

Unity-Character-Mechanism is a framework aiming to facilitate the code development of a
character in Unity. The framework comes with two version: **Light** and **Normal** ; each version
is made for a specific need, so be sure to checkout which version fit your requirements.
*(For more advance information about a version check there own documentation)*

**Supported Character Type**: AI / Player

**Supported Space**: Generic / 2D / 3D

**Supported Motion**: Root Motion / Script

**Supported Native Feature**: NavMesh *(Only for 3D)*

## Light

### Description

The Light Character mechanism is an abstract class to inherit in order to create your own
character mechanism. The goal of this version is to provide a basic structure of code with
a low cost in memory and less code to maintain compared to the Normal version.

### Why use it

The Light Character Mechanism is made for low complex character mechanism implementation ;
this means that if you have less than five action states, you should use it.

## Normal

### Description

The Normal Character Mechanism are abstract class to inherit *(Behaviour and System)* in order to
create your own character mechanism. The goal of this version is to provide a basic structure of
code with reusable conditions, states, transitions and systems ; and standardize all the input
information.

All the sections of the code development of a character is divided into single part in order to
offer the most scalable, maintainable and reusable code. 

It's important to note that **condition, state and transition are single instance shared by all the
character mechanism** ; this means that no matter the number of Normal Character Mechanism you have
only there mechanism will be instantiated, so the memory cost is highly reduced. 

### Why use it

The Normal Character Mechanism is advised to be used when you have multiple duplicated conditions,
states, transitions or systems ; or when you have more than four
action states.

## Project Information

Developed and tested under **Unity 2018.3.0f2**

Made by **Antoine Morel**

Version **3.1.0**

# License

LICENSE MIT
