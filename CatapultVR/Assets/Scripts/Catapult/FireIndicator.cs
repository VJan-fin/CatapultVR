using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireIndicator : MonoBehaviour {

    public Material canFire;
    public Material cannotFire;

    Renderer cannonRenderer;

    // Use this for initialization
    void Start () {
        cannonRenderer = GetComponent<Renderer>();
        cannonRenderer.material = cannotFire;
	}

    public void ReadyToFire()
    {
        cannonRenderer.material = canFire;
    }

    public void NotReadyToFire()
    {
        cannonRenderer.material = cannotFire;
    }
	
}
