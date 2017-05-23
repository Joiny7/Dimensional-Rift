using UnityEngine;
using System.Collections;

public class BombScript : MonoBehaviour {

    public GameObject particle;
	private Animator animator;
	private bool activated = true;
	Color myColor = new Color();
    public float rotationSpeed = 90f;
	public Rigidbody rb;
	public bool TestGravity = false;

	void Start () {
		animator = GetComponent<Animator> ();
		animator.speed = 0.0f;													//Animation is not playing at start
		ColorUtility.TryParseHtmlString("ff0000", out myColor); 				//Color of emissive glow
	}

    void OnTriggerEnter(Collider trigger){
        if (trigger.CompareTag("SphereDestroyer")) {
			GameObject explosion = Instantiate(particle, transform.position, Quaternion.identity) as GameObject;
            Destroy(gameObject); 												// destroy the object
            Destroy(explosion, 3); 												// delete particle effect after 3 seconds
        }

		if (trigger.CompareTag("BombActivator"))
        {
			animator.speed = 1.0f;												//Activate animation at normal speed
			activated = true;
		}

		if (trigger.CompareTag("LaserDestroyer")) { 									//Shield collision
			if (TestGravity) {
				rb.useGravity = true;
			}
		}
    }

// Update is called once per frame
void Update () {
		if (activated) {
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
            Renderer renderer = GetComponent<Renderer>();
		    Material mat = renderer.material;
		    float floor = 0.5f; 												//Minimum glow
		    float ceiling = 1.2f; 												//Maximum glow
		    float emission = floor + Mathf.PingPong(Time.time * 1.1f, ceiling - floor); //Multiply time with constant for speed of glow
		    Color finalColor = myColor * Mathf.LinearToGammaSpace(emission);
		    mat.SetColor("_EmissionColor", finalColor);
        }
	}
}