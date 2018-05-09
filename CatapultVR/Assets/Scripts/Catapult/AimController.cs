using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimController : MonoBehaviour {

    public float turnSpeed;
    
	void Start () {
        turnSpeed = 4.0f;
	}

    public void Rotate(float angle)
    {
        transform.RotateAround(transform.position, transform.up, angle * turnSpeed * Time.deltaTime);
    }
}
