using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceManager : MonoBehaviour {

	public float launchDifference = 1.0f;

	SpoonController catapult;
	SizeController catapultSize;
	ControllerManager controllers;
	bool waitingForFire;
	Hand hand;
	Vector3 handPosition;


	public void Start() {
		catapult = GameObject.FindGameObjectWithTag ("Catapult").GetComponent<SpoonController> ();
		catapultSize = GameObject.FindGameObjectWithTag ("Catapult").GetComponent<SizeController> ();
		waitingForFire = false;
		handPosition = Vector3.zero;
		controllers = GetComponent<ControllerManager> ();
		hand = controllers.right;
	}

	public void Update() {
		if (waitingForFire) {
			HandleFire ();
		}
	}

	public void ReadyCatapult() {
		waitingForFire = false;
		catapult.Reset ();
	}

	public void PrepareFire() {
		float leftY = controllers.left.transform.localPosition.y;
		float rightY = controllers.right.transform.localPosition.y;

		if (leftY > rightY) {
			hand = leftY;
			handPosition = controllers.left.transform.localPosition;
		} else {
			hand = rightY;
			handPosition = controllers.right.transform.localPosition;
		}
		waitingForFire = true;
	}

	private void HandleFire() {
		float handY = hand.transform.localPosition.y;
		if (handY < handPosition.y - launchDifference) {
			waitingForFire = false;
			catapult.Fire ();
		}
	}

	public void GrowCatapult(){
		catapultSize.Grow (1.1f);
	}

	public void ShrinkCatapult(){
		catapultSize.Grow (0.9);
	}


}
