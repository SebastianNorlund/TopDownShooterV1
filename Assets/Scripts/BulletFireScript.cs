using UnityEngine;
using UnityEngine.InputSystem;

public class BulletScript : MonoBehaviour
{
    public GameObject Bullet;

    public float bulletSpeed = 2f;

    public Transform BulletSpawnPoint;

    public float fireDelay = 0.2f;

    public float nextFireTime = 0f;


    // Update is called once per frame
    void Update()
    {
        var kb = Keyboard.current; // shortcut so u dont have to type Keyboard.Current every time

        if (kb != null && kb.eKey.isPressed && Time.time >= nextFireTime) // if there exists a keyboard, e key is pressed and enough time has passed since the last shot
        {
            FireBullet();
            nextFireTime = Time.time + fireDelay; // the earliest time we're allowed to shoot again
        }
    }


    void FireBullet()
    {
     GameObject SpawnedBullet = Instantiate(Bullet, BulletSpawnPoint.position, transform.rotation); // instantiates bullet and references it so it can be destroyed
        Destroy(SpawnedBullet, 3f); // destroys bullet after 3 seconds so that bullets that miss dont fly forever

        Rigidbody2D rb2D = SpawnedBullet.GetComponent<Rigidbody2D>(); // gets the spawned bullets rigidbody
        if (rb2D != null) // only move if the bullet prefab actually has a Rigidbody2D
        {
            rb2D.linearVelocity = transform.up * bulletSpeed; // shoots in the direction the player is facing
        }
    }
}