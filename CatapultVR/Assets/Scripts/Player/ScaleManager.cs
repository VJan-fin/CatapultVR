using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleManager : MonoBehaviour {

    public SizeController catapultSize;
    ControllerManager controllers;
    Hand left, right;
    public float scaleFactor = 0.1f;

	// Use this for initialization
	void Start () {
        controllers = GetComponent<ControllerManager>();
        left = controllers.left;
        right = controllers.right;
    }
	
	// Update is called once per frame
	void Update () {
        float scale = GetScaling() * scaleFactor;
        if(scale != 0.0f)
        {
            float ratio = 1.0f + scale;
            catapultSize.Grow(ratio);
        }
	}

    private float GetScaling()
    {
        float sign = Mathf.Sign(right.trackpadY) * Mathf.Sign(left.trackpadY);
        if (sign > 0.0f)
        {
            float maginitude = Mathf.Min(Mathf.Abs(right.trackpadY), Mathf.Abs(left.trackpadY));
            return maginitude * Mathf.Sign(right.trackpadY);
        }
        return 0.0f;
    }
}
