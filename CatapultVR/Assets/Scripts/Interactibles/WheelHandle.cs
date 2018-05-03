using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelHandle : MonoBehaviour {

	Vector3 savedPosition;

    Vector3 initialPositon;
	Quaternion initialRotation;
    float distanceToAxel;

	public Transform wheelTransform;

    public Transform axelTransform;
    private Vector3 axelPosition;
    private Vector3 axelToInitialPosition;

    Rigidbody body;

	// Use this for initialization
	void Start () {
		savedPosition = transform.position;
		initialPositon = transform.localPosition;
		initialRotation = transform.localRotation;
		axelPosition = axelTransform.localPosition;
        axelToInitialPosition = initialPositon - axelPosition;
        distanceToAxel = axelToInitialPosition.magnitude;
        body = GetComponent<Rigidbody>();
		

		Debug.Log ("initialPosition: " + initialPositon);
		Debug.Log ("axelPosition: " + axelPosition);
		Debug.Log ("axelToInitialPosition: " + axelToInitialPosition);
		Debug.Log ("distanceToAxel: " + distanceToAxel);

    }
	
//	// Update is called once per frame
	void Update () {
		
        float angle = GetAngle();

        RotateWheel(angle);
		RestrictMovement ();

		Debug.Log (angle);
    }

    float GetAngle() {
		Vector3 currentPosition = transform.localPosition;
		currentPosition.y = initialPositon.y;

        Vector3 axelToCurrentPosition = currentPosition - axelPosition;

        float angle = Vector3.SignedAngle(axelToInitialPosition, axelToCurrentPosition, axelTransform.up);
        //this.transform.position = newPosition;
        return angle;
    }

    void RotateWheel(float angle) {
        Quaternion newRotation = Quaternion.Euler(0, angle, 0);
		wheelTransform.Rotate (new Vector3(0, angle, 0));
    } 

    void RestrictMovement() {
		transform.localPosition = initialPositon;
		transform.localRotation = initialRotation;
    }
}
