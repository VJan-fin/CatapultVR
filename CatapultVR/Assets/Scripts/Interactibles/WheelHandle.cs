using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelHandle : MonoBehaviour {

    Vector3 initialPositon;
	Quaternion initialRotation;
    float distanceToAxel;

	public Transform wheelTransform;

    public Transform axelTransform;
    private Vector3 axelPosition;
    private Vector3 axelToInitialPosition;

    public float speedFactor;
    public AimController catapult;

    Rigidbody body;

	// Use this for initialization
	void Start () {
		initialPositon = transform.localPosition;
		initialRotation = transform.localRotation;
		axelPosition = axelTransform.localPosition;
        axelToInitialPosition = initialPositon - axelPosition;
        distanceToAxel = axelToInitialPosition.magnitude;
        body = GetComponent<Rigidbody>();
        speedFactor = 0.3f;

    }
	
//	// Update is called once per frame
	void Update () {
		
        float angle = GetAngle();

        RotateWheel(angle);
        RotateCatapult(angle);
		RestrictMovement ();
    }

    float GetAngle() {
		Vector3 currentPosition = transform.localPosition;
		currentPosition.y = initialPositon.y;

        Vector3 axelToCurrentPosition = currentPosition - axelPosition;

        float angle = Vector3.SignedAngle(axelToInitialPosition, axelToCurrentPosition, axelTransform.up);
        //this.transform.position = newPosition;
        
        return angle * speedFactor;
    }

    void RotateWheel(float angle) {
		wheelTransform.Rotate (new Vector3(0, angle, 0));
    }

    private void RotateCatapult(float angle) {
        catapult.Rotate(angle);
    }


    void RestrictMovement() {
		transform.localPosition = initialPositon;
		transform.localRotation = initialRotation;
    }
}
