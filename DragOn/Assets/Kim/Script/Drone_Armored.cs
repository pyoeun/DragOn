using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone_Armored : MonoBehaviour
{
    public int health = 100;
    public float speed = 4;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health -= 30;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
