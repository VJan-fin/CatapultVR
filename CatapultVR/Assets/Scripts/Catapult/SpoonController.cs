using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpoonController : MonoBehaviour {

	public float firepower = 800.0f;
	Spoon spoon;
	SizeController sizeController;


	// Use this for initialization
	void Start () {
		spoon = GetComponentInChildren<Spoon> ();
		sizeController = GetComponent<SizeController> ();
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
				float fp = firepower * sizeController.scale;
				ballBody.AddForce (direction * fp);
			}
		}
	}

	public void Reset() {
		this.spoon.Reset ();
	}
}
