using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabManager : MonoBehaviour {

    public Hand left, right;
    private BallHolder ballHolder;

	// Use this for initialization
	void Start () {
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
