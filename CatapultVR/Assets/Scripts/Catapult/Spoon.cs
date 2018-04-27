using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spoon : MonoBehaviour {

	public Ball held { get; private set;}
	private BoxCollider[] boxColliders;


	public void Start(){
		boxColliders = GetComponents<BoxCollider>();
	}

	public void Shoot(){
		StartCoroutine (RotateHandle ());
		DisableBoxColliders ();
	}

	IEnumerator RotateHandle() {
		float moveSpeed = 0.01f;
		// TODO check if there is a better way to check angles
		while (CurrentYAngle() < 360) {
			// Debug.Log ("in while: " + currentYAngle());
			transform.localRotation = Quaternion.Slerp (transform.localRotation, Quaternion.Euler (0, 360, 0), moveSpeed * Time.time);
			yield return null;
		}
		transform.localRotation = Quaternion.Euler (0, 360, 0);
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
			Debug.Log("new held ball");
		}
	}

	void OnTriggerStay (Collider other)
	{
		Ball ball = other.GetComponent<Ball>();
		if (ball && !held) {
			held = ball;
			Debug.Log ("held a staying ball");
		}
	}

	void OnTriggerExit (Collider other)
	{
		Ball ball = other.GetComponent<Ball>();
		if (held && held == ball) {
			held = null;
			Debug.Log("Ball exited");
		}
	}
}
