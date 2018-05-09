using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabManager : MonoBehaviour {

    ControllerManager controllers;
    Hand left, right;
    private BallHolder ballHolder;

	// Use this for initialization
	void Start () {
        controllers = GetComponent<ControllerManager>();
        left = controllers.left;
        right = controllers.right;
        ballHolder = GetComponentInChildren<BallHolder>();
	}
	
	void FixedUpdate () {
        ballHolder.Center(left, right);
	}

    public void GrabBall() 
	{ 
		if (!(left.collidingObject && right.collidingObject)) 
		{
			return;
		}
		Ball ball = right.collidingObject.GetComponent<Ball> ();
		if (left.collidingObject.GetComponent<Ball>() == ball) {
			left.Grab (ball.gameObject);
			right.Grab (ball.gameObject);
			ballHolder.HoldBall (ball);
        }
    }

	public void ReleaseBall() 
	{
        // TODO: Do some checks to verify that hands are far apart
        Debug.Log(name + "being asked to release ball");
		ballHolder.DropBall ();
		left.Release ();
		right.Release ();
	}

	public void GrabObject(Hand hand, GameObject obj) 
	{
        if (ballHolder.held) {
            return;
        }
		// Add code here if we want to check for two-handed objects.
		hand.Grab (obj);
    }

	public void ReleaseObject(Hand hand, GameObject obj) 
	{
		// For now it's simple because there are no two-handed objects yet.
        hand.Release();
    }
}
