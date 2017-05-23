using UnityEngine;
using System.Collections;

public class CurveSpawner2Script : SpawnerScript {
    public GameObject CurveProjectileEmitter2;
    public GameObject SphereYellow2;
    public float Forward_force;
    public GameObject CurveSpawner2;

    public override void Teleport(){
        CurveSpawner2.transform.position = new Vector3(Random.Range(1.4f, 1.8f), Random.Range(1.2f, 2.05f), 15f);
    }

    void Update(){
        timer += Time.deltaTime;
        if ((delay * difficultyMulti) <= timer && active)
        {
            Teleport();
            GameObject Temp_Projectile_Handler;
            Temp_Projectile_Handler = Instantiate(SphereYellow2, CurveProjectileEmitter2.transform.position, CurveProjectileEmitter2.transform.rotation) as GameObject;
            Rigidbody Temp_RigidBody;
            Temp_RigidBody = Temp_Projectile_Handler.GetComponent<Rigidbody>();
            Temp_RigidBody.AddForce(transform.forward * Forward_force);
            Destroy(Temp_Projectile_Handler, 8f);
            timer = 0;
        }
    }
}