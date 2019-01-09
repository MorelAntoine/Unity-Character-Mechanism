# Changelog

## 3.1.0

### Add

- Character Behaviour *(Generic, 2D, 3D, Generic Nav and Nav 3D)*

- ACharacterSystem

### New

- **Behaviour** and **System** are now separated (the unification had problems with the use of generic action state)
- Example are updated to match the new Normal Character Mechanism framework
- New API functions for behaviour information *(InitializeInformation and LoadInformationComponents)*
- New example *(FollowAIBehaviour)* for the Normal Character Mechanism

### Remove

- Character Mechanism

## 3.0.0

### Add

- Add **Light Character Mechanism**
    - Example *(LightFollowAI, LightPatrolAI and LightPlayer)*
    - Mechanism *(Generic, 2D, 3D, Generic Nav and Nav 3D)*

- Add **Normal Character Mechanism** *(Previous version entirely reworked)*
    - Example *(Player)*
    - Input Information *(Interface and LocomotionInformation)*
    - Mechanism *(Generic, 2D, 3D, Generic Nav and Nav 3D)*

### New

- AMotion has been replaced by AAction
- **API entirely simplified and cleaned**
- Light version for low complex character mechanism
- New editor GUI *(Normal)*
- **Simplify the use of external plugins or systems**
- Support **activation** *(Enable, Disable and Destroy)*
- Support **collision detection** *(2D and 3D)*
- Support **multiple editing in inspector**
- Support **multiple input information type**
- Support **trigger collision detection** *(2D and 3D)*
- Support **trigger transition**

### Remove

- Character Behaviour

- Character System

- Motion State Machine

## 2.0.1

- AMotionState are now clone to allow use of parameters

## 2.0.0

### Add 

- Documentation
- Example *(AIFollow, Player, Condition, State and Transition)*
- Nav Character Behaviour
- Prefab *(AIFollow and Player)*

### New

- API reworked and cleaned
- Support NavMesh

## 1.0.0

- Add Character Behaviour *(Generic)*

- Add Character System *(Generic, 2D and 3D)*