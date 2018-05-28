# Catapult VR

Developed at EPFL by Viktor Janevski and Leonardo Aoun.

## 1. Story

Set in medieval times, the player finds themselves amidst a Viking village. At the beginning of the game, the user is presented with a wooden catapult, two barrels and a wheel. Across them, in the nearby proximity of the village, is an intimidatingly large stone fortress that safeguards the treasures, weapons and shields taken from the villagers as tax by the oppressors. The challenge is to breach as many of the stronghold's walls as possible, as fast as possible.

CatapultVR is a timed game. Every session lasts for five minutes and the objective within this limited time is to achieve a score which is as high as possible by crashing the fortress' walls using the catapult. The gameplay requires the user to physically move within a small and limited space around them, use their arms and hands to interact with some objects in the virtual environment and use speech to issue particular predefined voice commands recognised by the game.

When the time of a single game expires, this is announced with audio inside the game, the cannonballs disappear and the score freezes. After five seconds the game will return to its initial position, waiting for the user to trigger the start of a new game by saying out loud a pre-specified keyword.

## 2. Hardware requirements

The bare minimum needed to be able to enjoy the game is an HTC Vive system consisting of a headset (HMD), two controllers and two base stations. A pair of headphones or an alternative audio output is also recommended in order to increase the enjoyment and flow of playing the game, even though it is not absolutely indispensable to have one.

## 3. Spatial requirements

Assuming the HTC Vive system has been properly calibrated, a rectangular area of approximately 3.5m x 1.5m is sufficient to be able to interact with all the objects. They are carefully positioned near the user and do not require a lot of physical displacement.

## 4. Software and credits

The entire game was developed using Unity 2017.3.1 and Blender version 2.79b for making animations, tweaking some models and achieving the effect of breaking the fortress elements. There was no modeling done for the purpose of the game. All the sound effects, models, materials, textures and assets are available for free online. The great majority of them can be found for free in the Unity Asset Store.

The most prominent asset packages used in the CatapultVR game include:
- **Viking Village** by *Unity Technologies*: used for building the village surrounding the player 
- **Unity Particle Pack** by *Unity Technologies*: special effects, fire and explosions
- **Realistic Terrain Collection LITE** by *400M Creations*: used for creating the terrain, the surrounding mountains and the nature
- **Medieval Castle Pack Lite** by *Tsunoa Games*: used for building the fortress
- **Classic Skybox** by *MGSVEVO*: used for the sky
- **Volumetric Lines** by *Johannes Unterguggenberger*: used for the particle system that creates the mist and the clouds in the scene
- **Medieval Gold** and **2 Old Boxes** by *Mister Necturus*: used for the props, gold coins and weapons inside the fortress

Furthermore, SteamVR SDK for Unity, available in the Unity Asset Store, is used to integrate the HTC Vive system into the application. The version of the plugin used is 1.2.3. In order to implement animations, in particular the fade out effect of broken down fortress elements, the iTween library by Pixelplacement was used.

All the physics requirements were satisfied by using the built-in Unity physics engine.

## 5. Short video demo

Click on the video thumbnail to follow the link to YouTube.

[![IMAGE ALT TEXT HERE](https://img.youtube.com/vi/exYYukBjsQE/0.jpg)](https://www.youtube.com/watch?v=exYYukBjsQE)
