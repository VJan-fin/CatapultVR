using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour {

    public GameObject explosionEffect;
    public Rigidbody objRigidBody;
    public BoxCollider objBoxCollider;
    public GameObject wholeObj;
    public GameObject pieces;
    public AudioSource explosionSoundEffect;

    public float vanishingTime = 3.0f;
    public float vanishingDelay = 7.5f;

    ScoreManager scoreManager;

	// Use this for initialization
	void Start () {
        scoreManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<ScoreManager>();
	}

    private void OnCollisionEnter(Collision collision)
	{
        if (collision.gameObject.GetComponent<Ball>())
        {
            this.Explode();
            this.PerformDestructionAction();
            float destructionRadius = collision.gameObject.GetComponent<Ball>().hitRadius;

            Collider[] neighbours = Physics.OverlapSphere(transform.position, destructionRadius);
            foreach (Collider neighbour in neighbours) 
            {
                if (neighbour.GetComponent<Destructible>())
                {
                    neighbour.GetComponent<Destructible>().PerformDestructionAction();
                }
            }
        }
	}

    public void PerformDestructionAction() 
    {
        this.Destruct();
        this.Vanish();
    }

    private void Explode()
    {
        // Show effect
        GameObject ps = Instantiate(explosionEffect, transform.position, transform.rotation);
        explosionSoundEffect.Play();

        // Destroy the particle system after it executes the effect
        Destroy(ps, ps.GetComponent<ParticleSystem>().main.duration);
    }

    private void Destruct()
    {
        scoreManager.Destroyed(this);
        objRigidBody.isKinematic = true;
        objBoxCollider.enabled = false;
        wholeObj.SetActive(false);
        pieces.SetActive(true);
    }

    private void SetMaterialTransparent()
    {
        foreach (Transform child in pieces.transform)
        {
            foreach (Material m in child.gameObject.GetComponent<Renderer>().materials)
            {
                m.SetFloat("_Mode", 2);
                m.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                m.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                m.SetInt("_ZWrite", 0);
                m.DisableKeyword("_ALPHATEST_ON");
                m.EnableKeyword("_ALPHABLEND_ON");
                m.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                m.renderQueue = 3000;
            }
        }
    }

    private void Vanish() 
    {
        SetMaterialTransparent();
        iTween.FadeTo(gameObject, iTween.Hash(
            "alpha", 0f,
            "time", vanishingTime,
            "delay", vanishingDelay,
            "onComplete", "RemoveObject"
        ));
    }

    private void RemoveObject()
    {
        Destroy(gameObject);
    }
}
