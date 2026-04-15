# SyncDash

Sync Dash is a hyper-casual runner game built in Unity. The screen is split into two halves:

Right Side: Player-controlled cube
Left Side: Ghost cube that mimics player actions with a simulated network delay

This project focuses on demonstrating real-time synchronization concepts, efficient memory usage through object pooling, and smooth gameplay systems without relying on a multiplayer backend.

**Key Features**

Simulated real-time synchronization using a queue-based delay system
Ghost replay system with smooth interpolation
Object pooling for performance optimization
Increasing difficulty through progressive speed scaling
Lane-based obstacle spawning system
Mobile-friendly lightweight architecture

**Gameplay**
Objective
  Survive as long as possible
  Avoid obstacles
  Collect orbs to increase score
  
**Controls**
Jump	Mouse Click / Tap

**Core Systems**

**Player Movement**
  Automatic forward motion using Rigidbody physics
  Jump implemented using impulse force
  Gradual speed increase for difficulty scaling
  
**Ghost System (Simulated Multiplayer)**

  Player state is continuously sent to SyncManager
  Data stored using FIFO queue
  Artificial delay simulates network latency
  Interpolation ensures smooth ghost movement
  
**Spawning System**

  Obstacles and orbs spawn dynamically ahead of the player
  Lane-based system using fixed positions (-2, 0, 2)
  Objects move toward the player
  
**Object Pooling**

  Pre-instantiated objects reused at runtime
  Eliminates frequent allocation and deallocation
  Reduces garbage collection overhead
  
**Score System**
  Distance-based scoring
  Additional points from orb collection

  
**  Main Scripts**

**PlayerController**

Handles movement, jumping, and physics
Sends player state to SyncManager

**SyncManager**

Maintains queue of player states
Applies delay for synchronization simulation

**GhostController**

Reads delayed states
Applies interpolation for smooth replay

**GameManager**

Handles spawning logic
Manages object pooling
Controls object movement

**Orb**

Controls animation (rotation and floating)
Handles score collection


**Synchronization Logic**

1. Player generates state data:
  Position
  Velocity
  Jump state

2. SyncManager:
Stores data in queue
Applies artificial delay

3. Ghost:
Retrieves delayed data
Uses interpolation (Lerp) for smooth movement

**Performance Considerations**

Object pooling avoids runtime instantiation spikes
Minimal physics calculations for mobile efficiency
Lightweight synchronization logic
Optimized update loops

