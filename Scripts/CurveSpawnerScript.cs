using UnityEngine;
using System.Collections;

public class CurveSpawnerScript : SpawnerScript
{
    public GameObject CurveProjectileEmitter;
    public GameObject SphereYellow;
    public float Forward_force;
    public GameObject CurveSpawner;

    public override void Teleport(){
        CurveSpawner.transform.position = new Vector3(Random.Range(-1.8f, -1.4f), Random.Range(1.2f, 2.05f), 15f);
     //   CurveSpawner.transform.position = new Vector3(Random.Range(-2.047f, -1.449f), Random.Range(1.3f, 1.9f), 15f);
    }

    void Update(){
        timer += Time.deltaTime;
        if ((delay* difficultyMulti) <= timer && active)
        {
            Teleport();
            GameObject Temp_Projectile_Handler;
            Temp_Projectile_Handler = Instantiate(SphereYellow, CurveProjectileEmitter.transform.position, CurveProjectileEmitter.transform.rotation) as GameObject;
            Rigidbody Temp_RigidBody;
            Temp_RigidBody = Temp_Projectile_Handler.GetComponent<Rigidbody>();
            Temp_RigidBody.AddForce(transform.forward * Forward_force);
            Destroy(Temp_Projectile_Handler, 8f);
            timer = 0;
        }
    }
}
