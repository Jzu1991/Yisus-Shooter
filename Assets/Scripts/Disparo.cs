using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public GameObject Bullet;
    public float bulletforce;


    public Vector3 Spawnposition;



    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bulletclone = Instantiate(Bullet, transform.position, transform.rotation);

            Rigidbody bulletRigidBody = bulletclone.GetComponent<Rigidbody>();

            bulletRigidBody.velocity = transform.forward * bulletforce;

            Destroy(bulletclone, 2f);

        }



    }
}
