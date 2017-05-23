using UnityEngine;
using System.Collections;

public class BombSpawnerScript : SpawnerScript {

    public GameObject BombEmitter;
    public GameObject Bomb;
    public float Bomb_Speed;
    public GameObject BombSpawner;
    public float SpawnTimer;


    public override void Teleport()
    {
        BombSpawner.transform.position = new Vector3(Random.Range(-1.0f, 0.8f), Random.Range(0.8f, 1.5f), 14.6f);
    }


    // Update is called once per frame
    void Update(){
		timer += Time.deltaTime;
		if ((delay * difficultyMulti) <= timer && active)
        {
			Teleport();

            GameObject Temp_Projectile_Handler;
            Temp_Projectile_Handler = Instantiate(Bomb, BombEmitter.transform.position, BombEmitter.transform.rotation) as GameObject;
            Rigidbody Temp_RigidBody;
            Temp_RigidBody = Temp_Projectile_Handler.GetComponent<Rigidbody>();
			Temp_RigidBody.AddForce(transform.forward * (Bomb_Speed* speedMulti));
            Destroy(Temp_Projectile_Handler, 7.5f);
            timer = 0;
        }
    }
}

