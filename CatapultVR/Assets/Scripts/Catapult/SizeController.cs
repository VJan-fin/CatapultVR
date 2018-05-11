using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeController : MonoBehaviour {

	public Transform ballHolder;
	Spoon spoon;
	Vector3 initialScale;
    Vector3 initialPosition;
	public float scale{ get; private set;}

	// Use this for initialization
	void Start () {
		spoon = GetComponentInChildren<Spoon> ();
		initialScale = transform.localScale;
        initialPosition = transform.localPosition;
		scale = 1.0f;
	}

	public void Grow(float ratio) {
		Ball ball = spoon.held;

		scale *= ratio;
        scale = Mathf.Clamp(scale, 0.75f, 2.0f);
		transform.localScale = initialScale * scale;
        float move = 1.0f - scale;
        transform.localPosition = initialPosition + (move * transform.right);

		if (ball) {
            Debug.Log(name + "keeping ball in place");
			ball.transform.position = ballHolder.position;
		}
	}
}
