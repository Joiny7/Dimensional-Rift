using UnityEngine;
using System.Collections;

public class SphereMScript : MonoBehaviour{
    public GameObject particleEffect; // drag our effect prefab here
    public GameObject spawnParticle;
    public float rotationSpeed = 90f;
    public float curveForce = 1.5f;
	public bool TestGravity = false;
	public Rigidbody rb;
    public float difficultyMulti;

    void Update(){
 		transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
		transform.Translate(Vector3.right * curveForce * Time.deltaTime);
    }



    void OnTriggerEnter(Collider coll){
		if (coll.CompareTag("SphereDestroyer")){ 			//If colliding with the sword
            GameObject explosion = Instantiate(particleEffect, transform.position, Quaternion.identity) as GameObject;
            Destroy(gameObject); // destroy the object
            Destroy(explosion, 3); // delete the effect after 3 seconds
        }

		if (coll.CompareTag("LaserDestroyer")) {				//If colliding with the shield
			curveForce = 0f;
			rotationSpeed = 0f;
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