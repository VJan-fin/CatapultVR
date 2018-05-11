using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireIndicator : MonoBehaviour {

    public Material canFire;
    public Material cannotFire;

    Renderer renderer;

    // Use this for initialization
    void Start () {
        renderer = GetComponent<Renderer>();
        renderer.material = cannotFire;
	}

    public void ReadyToFire()
    {
        renderer.material = canFire;
    }

    public void NotReadyToFire()
    {
        renderer.material = cannotFire;
    }
	
}
