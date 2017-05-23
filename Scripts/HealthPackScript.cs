using UnityEngine;
using System.Collections;

public class HealthPackScript : MonoBehaviour {
    public GameObject particleEffect; // drag our effect prefab here
    public GameObject spawnParticle;
    public float rotationSpeed = 90f;
    public Rigidbody rb;
    public bool TestGravity = false;
    float Curve_timer;
    public float thrust;
    public float Nthrust;
    bool x = false;
    bool y = false;

   /* void zigzag()
    {
        if (Curve_timer <= 0.3)
        {
            y = true;
            x = false;
        }
        if (Curve_timer >= 0.3)
        {
            x = true;
            y = false;
        } else
        {
            Curve_timer = 0;
        }
    }
    
    void Update()
    {
        //transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
        Curve_timer += Time.deltaTime;
        zigzag();
        if (y && !x)
        {
            rb.AddForce(transform.right * thrust);
        }
        if (x && !y)
        {
            rb.AddForce(transform.right * Nthrust);
        }
    }
   */ 
    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("SphereDestroyer"))
        {
            GameObject explosion = Instantiate(particleEffect, transform.position, Quaternion.identity) as GameObject;
            Destroy(gameObject); // destroy the object
            Destroy(explosion, 3); // delete the effect after 3 seconds
        }

        if (coll.CompareTag("LaserDestroyer"))
        {               //If colliding with the shield
            rotationSpeed = 0f;
            if (TestGravity)
            {
                rb.useGravity = true;
            }
        }

        if (coll.CompareTag("ParticleActivator"))
        {       //Spawns particle effect when the sphere go through the portal
            GameObject spawnSmoke = Instantiate(spawnParticle, transform.position, Quaternion.identity) as GameObject;
            Destroy(spawnSmoke, 3); // delete the effect after 3 seconds
        }
    }
}
