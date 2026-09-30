using UnityEngine;

public class BulletKillScript : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy") // checks if parent collided with gameobject tagged enemy
            {
            Destroy(gameObject); //destroys bullet
            Destroy(collision.gameObject); //destroys enemy

            }

        if(collision.gameObject.tag == "Wall") // checks if parent collided with gameobject tagged enemy
        {
            Destroy(gameObject); // destroys bullet

        }
    }
}
