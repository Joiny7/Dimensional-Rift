using UnityEngine;
using System.Collections;

public class LaserSpawnerScript : SpawnerScript {
    public GameObject LaserEmitter;
    public GameObject Laser;
    public float Laser_Speed;
    public GameObject LaserSpawner;
    public float SpawnTimer;
    //public GameObject warningParticle; //Varningspartikel som kommer upp på portalen
	GameObject warning;

    public override void Teleport(){
        LaserSpawner.transform.position = new Vector3(Random.Range(-1.0f, 0.23f), Random.Range(0.9f, 1.8f), 13.25f);

    }

    // Use this for initialization
//    void Start () {
//		warningParticle.SetActive (false);
//    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if ((delay * difficultyMulti) <= timer && active)
        {
            Teleport();
            GameObject Temp_Projectile_Handler;
            Temp_Projectile_Handler = Instantiate(Laser, LaserEmitter.transform.position, LaserEmitter.transform.rotation) as GameObject;
            Rigidbody Temp_RigidBody;
            Temp_RigidBody = Temp_Projectile_Handler.GetComponent<Rigidbody>();
            Temp_RigidBody.AddForce(transform.forward * (Laser_Speed* speedMulti));
            Destroy(Temp_Projectile_Handler, 6f);
            timer = 0;
//			warningParticle.SetActive (true);
//			warning = Instantiate(warningParticle, (LaserEmitter.transform.position + transform.position), Quaternion.identity) as GameObject;
//			Destroy (warning, 4);
        }
    }
}
	

