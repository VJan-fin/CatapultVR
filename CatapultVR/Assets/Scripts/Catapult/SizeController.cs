using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeController : MonoBehaviour {

	public Transform ballHolder;
	Spoon spoon;
	Vector3 initialScale;
	public float scale{ get; private set;}

	// Use this for initialization
	void Start () {
		spoon = GetComponentInChildren<Spoon> ();
		initialScale = transform.localScale;
		scale = 1.0f;
	}

	public void Grow(float ratio) {
		Ball ball = spoon.held;

		scale *= ratio;
		transform.localScale = initialScale * scale;

		if (ball) {
			ball.transform.position = ballHolder.position;
		}
	}
}
