using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHolder : MonoBehaviour {

    public Ball held { get; private set; }
	public float upModifier = 0.3f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Center(Hand left, Hand right)
    {
		// TODO Verify that up is the good direction
		this.transform.position = this.upModifier * transform.up +
			0.5f * (left.transform.position + right.transform.position);
    }

    public void HoldBall(Ball ball) 
	{
        if (this.held)
        {
            return;
        }

        var joint = AddFixedJoint();
        joint.connectedBody = ball.GetComponent<Rigidbody>();
    }

	public void DropBall()
	{
		if (!this.held) 
		{
			return;	
		}
		FixedJoint[] fxs = GetComponents<FixedJoint> ();
		if (fxs != null) 
		{
			foreach (FixedJoint fx in fxs)
			{
				fx.connectedBody = null;
				Destroy (fx);
			}
		}
		held = null;
	}

    private FixedJoint AddFixedJoint()
    {
        // Fixed Joints restricts an object’s movement to be dependent upon another object. 
        // This is somewhat similar to Parenting but is implemented through physics rather than Transform hierarchy.
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;  // The force that needs to be applied for this joint to break.
        fx.breakTorque = 20000;  // The torque (a force that tends to cause rotation) that needs to be applied for this joint to break.
        return fx;
    }
}
