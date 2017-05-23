using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour
{
    private GameObject laser;
    public Rigidbody rb;
    public float thrust;
    public float shrinkSpeed;
	GameObject sparks;
	public GameObject particleEffect; // drag our effect prefab here
	Color myColor = new Color();
	public float afterglow = 0.25f; //Set how long to wait before destroying particle effect
    private float floor = 0.5f;
    private float ceiling = 1.2f;
    public float difficultyMulti;

    // Use this for initialization
    void Start(){
        laser = this.gameObject;
        ColorUtility.TryParseHtmlString("ff0000", out myColor); //Color of emissive glow
        //setSpeed(DifficultyLevel.difficulty);
        //thrust = thrust * difficultyMulti;
    }

    void OnCollisionStay(Collision coll){
        if (laser.transform.localScale.z <= 0.03){
            Destroy(laser);
        }   
        else if (coll.collider.CompareTag("LaserDestroyer")){
            laser.transform.localScale += new Vector3(0, 0, shrinkSpeed);
			sparks = Instantiate(particleEffect, transform.position, Quaternion.identity) as GameObject;
            Destroy(sparks, afterglow); //delete the effect after x seconds
        }
    }

   /* public void setSpeed(int i)
    {
        if (i == 1) 					//Tutorial
        {
            difficultyMulti = 0.7f;
        }
        else if (i == 2)				//Easy
        {
            difficultyMulti = 0.8f;
        }
        else if (i == 3)				//Normal
        {
            difficultyMulti = 1.0f;
        }
        else if (i == 4)				//Hard
        {
            difficultyMulti = 1.2f;
        }
        else if (i == 5)                //Insane
        {
            difficultyMulti = 1.4f;
        }
    }*/

    // Update is called once per frame
    void Update(){
        rb.AddForce(transform.forward * thrust);
        Renderer renderer = GetComponent<Renderer>();
        Material mat = renderer.material;
        float emission = floor + Mathf.PingPong(Time.time * 0.8f, ceiling - floor); //Multiply time with constant for speed of glow
        Color finalColor = myColor * Mathf.LinearToGammaSpace(emission);
        mat.SetColor("_EmissionColor", finalColor);
    }
}