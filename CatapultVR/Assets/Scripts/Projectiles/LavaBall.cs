using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaBall : Ball
{
    public GameObject explosionEffect;
    public AudioSource explosionSoundEffect;

    public void ExplosionEffect()
    {
        // Show effect
        GameObject ps = Instantiate(explosionEffect, transform.position, transform.rotation);
        explosionSoundEffect.Play();

        // Destroy the particle system after it executes the effect
        Destroy(ps, ps.GetComponent<ParticleSystem>().main.duration);
    }

    public override void Explode()
    {
        if (this.isThrown)
        {
            this.ExplosionEffect();
            this.CrashNeighbouringDestructibles();
            //Destroy(gameObject, 3.0f);
            this.SelfDestroy(3.0f);
        }
    }

}
