using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelHandle : MonoBehaviour {

    Vector3 initialPositon;
    float distanceToAxel;

    private Transform wheelTransform;

    public Transform axelTransform;
    private Vector3 axelPosition;
    private Vector3 axelToInitialPosition;

    Rigidbody body;

	// Use this for initialization
	void Start () {
        initialPositon = transform.position;
        axelPosition = axelTransform.position;
        axelToInitialPosition = initialPositon - axelPosition;
        distanceToAxel = axelToInitialPosition.magnitude;
        body = GetComponent<Rigidbody>();
        wheelTransform = GetComponentInParent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
        RestrictMovement();
        float angle = GetAngle();
        RotateWheel(angle);
    }

    float GetAngle() {
        Vector3 currentPosition = transform.position;
        Vector3 axelToCurrentPosition = currentPosition - axelPosition;
        float magnitude = axelToCurrentPosition.magnitude;
        axelToCurrentPosition = axelToCurrentPosition / magnitude;
        Vector3 newPosition = axelPosition + axelToCurrentPosition * distanceToAxel;
        newPosition.y = initialPositon.y;
        axelToCurrentPosition = newPosition - axelPosition;
        float angle = Vector3.SignedAngle(axelToInitialPosition, axelToCurrentPosition, wheelTransform.up);
        //this.transform.position = newPosition;
        Debug.Log(angle);
        return angle;
    }

    void RotateWheel(float angle) {
        Quaternion newRotation = Quaternion.Euler(0, angle, 0);
        wheelTransform.rotation = wheelTransform.rotation * newRotation;
    } 

    void RestrictMovement() {
        body.velocity /= 2.0f;
        body.angularDrag /= 2.0f;
    }
}
