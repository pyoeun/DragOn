using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone_Destruct : MonoBehaviour
{
    public int health = 100;
    public float speed = 5;

    public SpawnManager spawnManager;

    // Update is called once per frame
    void Update()
    {
        this.transform.position += Vector3.left * speed * Time.deltaTime;

        if (this.transform.position.x < -12)
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            health -= 30;
            if(health <= 0)
            {
                //Æø*ÆÄ



                Destroy(gameObject);
            }
        }
    }
}
