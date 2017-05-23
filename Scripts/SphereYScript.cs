using UnityEngine;
using System.Collections;

public class SphereYScript : MonoBehaviour{
    public GameObject particleEffect; // drag our effect prefab here
    public GameObject spawnParticle;
    public float rotationSpeed;
    float Curve_timer;
    public Rigidbody rb;
    public float thrust;
	public bool TestGravity = false;

    void Start(){
        rb = GetComponent<Rigidbody>();
    }

    void Update(){
        transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
        Curve_timer += Time.deltaTime;
		if (Curve_timer >= 0.92){
			rb.AddForce(transform.right * thrust);
        }
    }

	void OnTriggerEnter(Collider coll){
		if (coll.CompareTag("SphereDestroyer"))
        {
            GameObject explosion = Instantiate(particleEffect, transform.position, Quaternion.identity) as GameObject;
            Destroy(gameObject); // destroy the object
            Destroy(explosion, 3); // delete the effect after 3 seconds
        }
		if (coll.CompareTag("LaserDestroyer")) {				//If colliding with the shield
			rotationSpeed = 0f;
			thrust = 0f;
			if (TestGravity) {
				rb.useGravity = true;
			}
		}
        if (coll.CompareTag("ParticleActivator")) {       //Spawns particle effect when the sphere go through the portal
            GameObject spawnSmoke = Instantiate(spawnParticle, transform.position, Quaternion.identity) as GameObject;
            Destroy(spawnSmoke, 3); // delete the effect after 3 seconds
        }
    }
}