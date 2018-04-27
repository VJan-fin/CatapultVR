using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpoonController : MonoBehaviour {

	public Spoon spoon;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//spoon.transform.Rotate (new Vector3 (0, 1f, 0));
	}

	public void Fire(){
		this.spoon.Shoot();
		if (spoon.held) {
			Rigidbody ballBody = spoon.held.GetComponent<Rigidbody>();
			if (ballBody) {
				Vector3 direction = (transform.forward + transform.up).normalized;
				ballBody.AddForce (direction * 1000.0f);
			}
		}
	}
}
