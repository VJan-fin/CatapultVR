using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour {

    public GameObject ball;

	// Use this for initialization
	void Start () {
        //SpawnBall();
	}
	
    public void SpawnBall()
    {
        Ball newBall =  Instantiate(ball, transform.position, transform.rotation).GetComponent<Ball>();
        newBall.spawner = this;
    }

}
