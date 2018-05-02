using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {

    // A reference to the object being tracked. In this case, a controller.
    private SteamVR_TrackedObject trackedObj;
    // Stores the GameObject that the trigger is currently colliding with, so the player can grab the object.
    public GameObject collidingObject { get; private set; }
    // Reference to the GameObject that the player is currently grabbing.
    public GameObject objectInHand { get; private set; }
    private GrabManager manager;

    // A Device property to provide easy access to the controller. 
    // It uses the tracked object’s index to return the controller’s input.
    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    /*
     * Awake is called when the script instance is being loaded.
     * Awake is used to initialize any variables or game state before the game starts. 
     * Awake is called only once during the lifetime of the script instance.
     * One should use Awake to set up references between scripts, and use Start to pass any information back and forth.
     */
    public void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        // if we get an error, move this to Start()
        manager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<GrabManager>();
    }
		
    public void FixedUpdate()
    {
		if (objectInHand) 
		{
			// If the hand was holding an object
			if (objectInHand.GetComponent<Ball> ()) 
			{
                Debug.Log("is holding hand" + gameObject.name);
				// If that object was a ball
				if (!collidingObject || !collidingObject.GetComponent<Ball>()) 
				{
                    Debug.Log(name + "hand not touching ball anymore");
					manager.ReleaseBall ();
				}
			} else { 
				if(Controller.GetHairTriggerUp())
				{
					// The reason why this logic is not handled in this class is:
					// If we want to have other objects than the ball that are two-handed,
					// We still don't handle this case, but just for later.
					manager.ReleaseObject(this, objectInHand);
				}
			}
		}  else if (collidingObject)
		{
			// If the hand encounters an object
			if (collidingObject.GetComponent<Ball>()) 
			{
				// If that object is a ball
				manager.GrabBall ();
			} else if(Controller.GetHairTriggerDown()) 
			{
				// Same reason as for ReleaseObject
				manager.GrabObject(this, collidingObject);
			}
		}
    }

    /* 
     * When the trigger collider enters another, this sets up the other collider as a potential grab target.
     */
    private void SetCollidingObject(Collider col)
    {
        // Doesn’t make the GameObject a potential grab target if the player is already holding something 
        // or the object to be grabbed has no rigidbody.
        if (collidingObject || !col.GetComponent<Rigidbody>())
        {
            return;
        }
        collidingObject = col.gameObject;  // Assign the object as a potential grab target.
    }

	public void Grab(GameObject obj)
    {
        objectInHand = obj;  // Move the GameObject inside the player’s hand.
        // TODO: not sure if we should actually keep this line.
		// collidingObject = null;  // Remove it from the collidingObject variable

		if (! obj.GetComponent<Ball>())
        {
            var joint = AddFixedJoint();
            // Reference to the Rigidbody that the joint is dependent upon.
            joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
        }
    }

    /* 
     * Make a new fixed joint, add it to the controller, and then set it up so it doesn’t break easily.
     */
    private FixedJoint AddFixedJoint()
    {
        // Fixed Joints restricts an object’s movement to be dependent upon another object. 
        // This is somewhat similar to Parenting but is implemented through physics rather than Transform hierarchy.
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;  // The force that needs to be applied for this joint to break.
        fx.breakTorque = 20000;  // The torque (a force that tends to cause rotation) that needs to be applied for this joint to break.
        return fx;
    }

    public void Release()
    {
		// Delete all fixed joints with the body
		FixedJoint[] fxs = GetComponents<FixedJoint> ();
		if (fxs != null) 
		{
			foreach (FixedJoint fx in fxs)
			{
				fx.connectedBody = null;
				Destroy (fx);
			}
		}

		// Apply movement to the body
		Rigidbody objectBody = objectInHand.GetComponent<Rigidbody> ();
		if (objectBody) 
		{
			objectBody.velocity = Controller.velocity;
			objectBody.angularVelocity = Controller.angularVelocity;
		}

		// Free the hand
        objectInHand = null;
    }


    /*
     * Used to print controller input in the command line log
     */
    private void LogInputs()
    {
        // Get the position of the finger when it’s on the touchpad.
        if (Controller.GetAxis() != Vector2.zero)
        {
            Debug.Log(gameObject.name + Controller.GetAxis());
        }

        // Pressing the hair trigger. It has special methods to check whether it is pressed or not.
        if (Controller.GetHairTriggerDown())
        {
            Debug.Log(gameObject.name + " Trigger Press");
        }

        // Releasing the hair trigger. It has special methods to check whether it is pressed or not.
        if (Controller.GetHairTriggerUp())
        {
            Debug.Log(gameObject.name + " Trigger Release");
        }

        // The grip is the side button on the controller, on the handle itself
        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
        {
            Debug.Log(gameObject.name + " Grip Press");
        }

        // The grip is the side button on the controller, on the handle itself
        if (Controller.GetPressUp(SteamVR_Controller.ButtonMask.Grip))
        {
            Debug.Log(gameObject.name + " Grip Release");
        }
    }

    /*
     * OnTriggerEnter is called when the Collider other enters the trigger.
     */
    public void OnTriggerEnter(Collider other)
    {
        SetCollidingObject(other);
    }

    /* 
     * OnTriggerStay is called almost all the frames for every Collider other that is touching the trigger.
     */
    public void OnTriggerStay(Collider other)
    {
        // Ensures that the target is constantly set when the player holds a controller 
        // over an object for a while
        SetCollidingObject(other);
    }

    /* 
     * OnTriggerExit is called when the Collider other has stopped touching the trigger.
     */
    public void OnTriggerExit(Collider other)
    {
        if (!collidingObject)
        {
            return;
        }

        // When the collider exits an object, abandoning an ungrabbed target, 
        // this code removes its target by setting it to null.
        collidingObject = null;
    }

}
