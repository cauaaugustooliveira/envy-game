# Envy

A 2D game project developed with **Unity and C#**, focused on building interactive environments, NPC behavior, dialogue systems, character movement, animations, and event-driven gameplay.

The project was created as a practical game development project, allowing me to implement gameplay systems from scratch and explore the interaction between code, animations, UI, physics, and level design inside Unity.

---

## Overview

Envy is a 2D Unity project featuring an explorable environment with interactive characters and objects.

The current implementation includes systems for:

* Player movement
* Character animations
* NPC movement and behavior
* NPC dialogue
* Dialogue progression
* Monologues
* Interactive objects
* Doors and transitions
* Trigger-based events
* Environmental interactions
* Timed gameplay events

The project is still under development and new mechanics and content may be added over time.

---

## Tech Stack

* **Unity**
* **C#**
* **Unity 2D**
* **Rigidbody2D**
* **Animator**
* **TextMesh Pro**
* **Unity UI**
* **Unity Input System**
* **Universal Render Pipeline**
* **2D Physics**

Current Unity version:

```text
Unity 6000.5.8f1
```

---

## Gameplay Systems

### Player Movement

The player movement system uses `Rigidbody2D` and normalized directional input to provide consistent movement in four directions.

The system keeps track of:

* Current movement direction
* Last movement direction
* Player velocity
* Teleportation between positions

Example structure:

```text
Player
├── PlayerMovement
└── PlayerAnimation
```

---

### Player Animation

Character animations are controlled through Unity's `Animator`.

The animation system detects the player's movement direction and updates parameters such as:

```text
IsMoving
MoveX
MoveY
```

The last movement direction is preserved so the character continues facing the correct direction while idle.

---

## NPC System

NPCs include autonomous movement behavior.

The `NPCWander` system allows characters to alternate between:

```text
IDLE
 ↓
MOVING
 ↓
IDLE
```

NPC movement includes:

* Random movement directions
* Configurable movement speed
* Configurable idle time
* Configurable movement duration
* Rigidbody2D-based movement
* Obstacle detection using raycasts
* Animation integration
* Temporary movement blocking

This allows NPCs to behave independently while still being controllable by other gameplay systems.

---

## Dialogue System

Envy contains a custom dialogue system built in C#.

Dialogue lines can contain:

* Character name
* Dialogue text
* Character portrait

Example structure:

```text
Dialogue
│
├── Character Name
├── Text
└── Portrait
```

The system also supports portrait transitions using fade animations.

Players can advance dialogue using:

```text
Mouse Click
E
Space
```

---

## Dialogue Progression

The dialogue architecture is divided into different components:

```text
DialogueManager
NPCDialogue
NPCDialogueProgression
MonologueTrigger
```

This makes it possible to separate the visual dialogue system from individual NPC behavior and progression logic.

Dialogue events can also trigger additional gameplay actions when conversations are completed.

---

## Monologue System

The project also supports monologues triggered by environmental events.

These can be activated when the player enters specific areas or fulfills certain conditions.

This system allows narrative events to happen without requiring direct interaction with an NPC.

---

## Environmental Events

Envy uses Unity triggers and coroutines to create event-driven interactions.

For example, an environmental trigger can:

1. Detect the player entering an area
2. Wait for a configurable amount of time
3. Trigger a monologue
4. Activate another GameObject
5. React to dialogue completion
6. Change the environment

This allows gameplay events to be built by combining reusable systems.

---

## Interactive Objects

The project contains reusable interaction logic for objects in the environment.

Interactions are designed around proximity and player input.

Examples include:

* Doors
* NPCs
* Trigger areas
* Environmental events
* Dialogue interactions

---

## Door System

Doors can transport the player between different locations inside the scene.

When the player approaches a door, an interaction prompt is displayed.

After pressing:

```text
E
```

the system:

```text
Player enters door
       ↓
Fade In
       ↓
Teleport Player
       ↓
Fade Out
```

The transition is handled using a coroutine and Unity's Animator system.

---

## Project Structure

```text
Assets/
│
├── Components/
├── Prefabs/
├── Scenes/
├── Scripts/
│   │
│   ├── Dialogue/
│   │   ├── DialogueManager.cs
│   │   ├── MonologueTrigger.cs
│   │   ├── NPCDialogue.cs
│   │   └── NPCDialogueProgression.cs
│   │
│   ├── Hall/
│   │   └── BeakoTrapTrigger.cs
│   │
│   ├── Player/
│   │   ├── PlayerMovement.cs
│   │   └── PlayerAnimation.cs
│   │
│   ├── Door.cs
│   ├── InteractObject.cs
│   ├── NPCLookTrigger.cs
│   └── NPCWander.cs
│
├── Settings/
└── TextMesh Pro/
```

---

## Scene

The current main development scene is:

```text
Assets/Scenes/SampleScene.unity
```

As the project grows, the scene structure may be reorganized into multiple environments.

---

## How to Run

### Requirements

You will need:

* Unity Hub
* Unity `6000.5.8f1` or a compatible version

Clone the repository:

```bash
git clone https://github.com/cauaaugustooliveira/envy-game.git
```

Open **Unity Hub** and select:

```text
Add → Add project from disk
```

Then select the cloned `envy-game` directory.

Open:

```text
Assets/Scenes/SampleScene.unity
```

and press **Play**.

---

## Controls

Current controls include:

```text
W / A / S / D     Movement
Arrow Keys        Movement
E                 Interaction / Dialogue
Space             Advance Dialogue
Mouse Click       Advance Dialogue
```

---

## What I Learned

Developing Envy gave me practical experience with several areas of game development, including:

* C# programming
* Component-based architecture
* Unity's GameObject system
* 2D physics
* Rigidbody movement
* Collision and trigger detection
* Raycasting
* Character animation
* Animator parameters
* NPC behavior
* Dialogue systems
* UI programming
* Coroutines
* Event-driven gameplay
* Environmental scripting
* Reusable gameplay components

One of the main goals of the project is to improve my ability to design gameplay systems that can interact with each other instead of placing all game logic inside a single script.

---

## Current Systems

```text
✅ Player Movement
✅ Player Animation
✅ NPC Movement
✅ NPC Obstacle Detection
✅ NPC Dialogue
✅ Dialogue Progression
✅ Character Portraits
✅ Monologues
✅ Interactive Objects
✅ Doors
✅ Scene Transitions
✅ Environmental Triggers
✅ Timed Events
```

---

## Future Improvements

Planned improvements may include:

* Improved NPC AI
* More complex dialogue progression
* Dialogue choices
* Game state persistence
* Save and load system
* Multiple scenes
* Improved interaction system
* Audio and sound effects
* Additional environmental events
* Improved animation transitions
* Refactoring gameplay systems
* Automated tests for isolated gameplay logic

---

## Screenshots

Screenshots and gameplay previews will be added as development progresses.

<!--
Example:

![Gameplay](docs/gameplay.png)
![Dialogue](docs/dialogue.png)
-->

---

## Project Status

🚧 **Work in Progress**

Envy is currently under development.

The repository represents an ongoing game development project and its systems, architecture, and content may change as development continues.

---

## Author

**Cauã Augusto de Oliveira**

Software Engineering student and Technical Graduate in Digital Game Development, focused on software development, backend systems, and game development.

* GitHub: [cauaaugustooliveira](https://github.com/cauaaugustooliveira)
* Portfolio: [orezindev.vercel.app](https://orezindev.vercel.app)
* LinkedIn: [Cauã Augusto de Oliveira](https://www.linkedin.com/in/cau%C3%A3-augusto-oliveira-2487362ba/)
