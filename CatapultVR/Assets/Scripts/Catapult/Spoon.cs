using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spoon : MonoBehaviour {

	public Ball held { get; private set;}
	private BoxCollider[] boxColliders;
	float initialYAngle;


	public void Start(){
		boxColliders = GetComponents<BoxCollider>();
		initialYAngle = CurrentYAngle ();
	}

	public void Shoot(){
		StopCoroutine (RotateHandleInverse ());
		StartCoroutine (RotateHandle ());
		DisableBoxColliders ();
	}

	public void Reset(){
		StopCoroutine (RotateHandle ());
		StartCoroutine (RotateHandleInverse ());
		EnableBoxColliders ();
	}

	public void info(){
		Debug.Log (CurrentYAngle ());
	}

	IEnumerator RotateHandle() {
		float moveSpeed = 0.1f;
		// TODO check if there is a better way to check angles
		while (CurrentYAngle() < 357) {
			// Debug.Log ("in while: " + currentYAngle());
			transform.localRotation = Quaternion.Slerp (transform.localRotation, Quaternion.Euler (0, 359, 0), moveSpeed * Time.time);
			yield return null;
		}
		transform.localRotation = Quaternion.Euler (0, 359, 0);
		yield return null;
	}

	IEnumerator RotateHandleInverse() {
		float moveSpeed = 0.1f;
		// TODO check if there is a better way to check angles
		while (CurrentYAngle() > initialYAngle + 1) {
			transform.localRotation = Quaternion.Slerp (transform.localRotation, Quaternion.Euler (0, initialYAngle, 0), moveSpeed * Time.time);
			yield return null;
		}
		transform.localRotation = Quaternion.Euler (0, initialYAngle, 0);
		yield return null;
	}

	private float CurrentYAngle() {
		float ret = transform.localRotation.eulerAngles.y % 360;
		if (ret <= 0) {
			ret += 360;
		}
		return ret;
	}

	private void DisableBoxColliders(){
		foreach (BoxCollider box in boxColliders) {
			box.enabled = false;
		}
	}

	private void EnableBoxColliders(){
		foreach (BoxCollider box in boxColliders) {
			box.enabled = true;
		}
	}

	void OnTriggerEnter (Collider other)
	{
		Ball ball = other.GetComponent<Ball>();
		if (ball && !held) {
			held = ball;
		}
	}

	void OnTriggerStay (Collider other)
	{
		Ball ball = other.GetComponent<Ball>();
		if (ball && !held) {
			held = ball;
		}
	}

	void OnTriggerExit (Collider other)
	{
		Ball ball = other.GetComponent<Ball>();
		if (held && held == ball) {
			held = null;
		}
	}
}
