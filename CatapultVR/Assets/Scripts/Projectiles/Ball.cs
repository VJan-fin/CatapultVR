using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public float hitRadius = 1.0f;
    public BallSpawner spawner = null;

    protected bool isThrown;

	private void Start()
	{
        this.isThrown = false;
	}

	public void MarkAsThrown()
    {
        this.isThrown = true;
    }

    public virtual void Explode()
    {
    }

    public void CrashNeighbouringDestructibles()
    {
        Collider[] neighbours = Physics.OverlapSphere(transform.position, this.hitRadius);
        foreach (Collider neighbour in neighbours)
        {
            if (neighbour.GetComponent<Destructible>())
            {
                neighbour.GetComponent<Destructible>().PerformDestructionAction();
            }
        }
    }
    
}
