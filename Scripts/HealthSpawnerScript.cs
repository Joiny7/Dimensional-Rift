using UnityEngine;
using System.Collections;

public class HealthSpawnerScript : SpawnerScript
{
    public GameObject HealthEmitter;
    public GameObject HealthObject;
    public float Forward_force;
    public GameObject HealthSpawner;

    public override void Teleport()
    {
        HealthSpawner.transform.position = new Vector3(Random.Range(-1.0f, 0.8f), Random.Range(1.1f, 1.65f), 14.6f);
    }

    // Update is called once per frame
    void Update(){
        timer += Time.deltaTime;
        if (delay <= timer && active && difficultyMulti <= 3)
        {
            Teleport();
            GameObject Temp_Projectile_Handler;
			Temp_Projectile_Handler = Instantiate(HealthObject, HealthEmitter.transform.position, HealthEmitter.transform.rotation) as GameObject;
            Rigidbody Temp_RigidBody;
            Temp_RigidBody = Temp_Projectile_Handler.GetComponent<Rigidbody>();
            Temp_RigidBody.AddForce(transform.forward * Forward_force);
            Destroy(Temp_Projectile_Handler, 8f);
            timer = 0;
        }
    }
}
