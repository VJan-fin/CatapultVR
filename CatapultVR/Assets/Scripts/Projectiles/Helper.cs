using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ExplodeCannonBall()
    {
        var cannonBalls = FindObjectsOfType<Ball>();
        foreach (var cannonBall in cannonBalls)
        {
            cannonBall.Explode();
        }
    }
}
