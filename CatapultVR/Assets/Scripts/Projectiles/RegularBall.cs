using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularBall : Ball {

	private void Start()
	{
        this.isThrown = false;
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Destructible>())
        {
            var destructible = collision.gameObject.GetComponent<Destructible>();
            destructible.Explode();
            destructible.PerformDestructionAction();

            this.CrashNeighbouringDestructibles();
            Destroy(gameObject, 7.5f);
        }
    }
    
}
