using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabManager : MonoBehaviour {

    public Hand left, right;

	// Use this for initialization
	void Start () {
        left.isDominantHand = false;
        right.isDominantHand = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TryGrab() {
        if (left.objectInHand || right.objectInHand) {
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
