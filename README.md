# Proposal: Angry Birds/Catapult VR

## 1. Project description

The basic idea of our game is inspired by the popular Angry Birds. The player would be given a
slingshot/catapult and their objective would be to destroy the towers located opposite of them by
shooting projectiles. The intention is to use naturalistic ways of operating the slingshot, which
means that the user should use their hands to choose the direction of fire and use the band
extension of the slingshot in order to give power to the projectile.

&nbsp;&nbsp;&nbsp;&nbsp;*a) A virtual 3D scene*

The game will contain a 3D virtual environment resembling the real world that the user can
explore and interact with.

&nbsp;&nbsp;&nbsp;&nbsp;*b) Head position and rotation tracking*

This is necessary in order to give the players a better shot and a way to aim at the target they
are firing projectiles at. The user should be able to move around: forward or backward to extend
the band on the slingshot, sideways or duck in order to get a different perspective and better
aim of the target.

&nbsp;&nbsp;&nbsp;&nbsp;*c) Control the 3D movement of at least one virtual 3D object*

Some of the interactions that will be implemented include holding the ball/projectile and put it in
the designated place in the catapult before firing, grabbing the band and pulling it back, aiming
by either rotating a crank, or grabbing the band and moving sideways. We could also let the
user detonate the bomb or activate some power while it is mid air by using voice commands.

&nbsp;&nbsp;&nbsp;&nbsp;*d) Physics and interactions*

To make the virtual environment and the gameplay itself realistic, we would need to take
advantage of a physics library, so that the projectile moves properly through the air (having
real-world forces such as gravity or friction influence its trajectory), but also manage the
collisions once the projectiles hit the intended targets.

## 2. Hardware

We can see two ways of the game being played:

&nbsp;&nbsp;&nbsp;&nbsp;a) The preferred hardware is an HTC Vive set, with an HMD and controllers for the
interactions, selections and manipulations of 3D objects. A simple alternative to this
would be an Oculus Rift.

&nbsp;&nbsp;&nbsp;&nbsp;b) With a Kinect that will allow for body and head tracking, but also to capture gestures for
object interactions and voice commands, and we can change the view on the screen
similar to what is done in the TP.

## 3. Software

Our intention is to use Unity 3D and some proprietary or open-source software depending on
the hardware.

## 4. Credits
- Use the hands from [3DHaupt](https://www.blendswap.com/blends/view/66039) and [Super Dasil](https://www.blendswap.com/blends/view/81285)
