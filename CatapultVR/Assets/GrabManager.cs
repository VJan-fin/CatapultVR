using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabManager : MonoBehaviour {

    public Hand left, right;
    private BallHolder ballHolder;

	// Use this for initialization
	void Start () {
        left.isDominantHand = false;
        right.isDominantHand = true;
        ballHolder = GetComponentInChildren<BallHolder>();
	}
	
	void FixedUpdate () {
        ballHolder.Center(left, right);
	}

    public void Hold(Ball ball) { 

        if (left.collidingObject.GetComponent<Ball>() != ball || right.collidingObject.GetComponent<Ball>() != ball) {
            return;
        }
        ballHolder.HoldBall(ball);
    }

    public void TryGrab() {
        if (ballHolder.held) {
            return;
        }
        if (left.collidingObject == right.collidingObject) {
            right.GrabObject();
            left.GrabObject();
            
        }
    }

    public void Release() {
        if (!left.objectInHand && !right.objectInHand) {
            return;
        }
        right.ReleaseObject();
        left.ReleaseObject();
    }
}
