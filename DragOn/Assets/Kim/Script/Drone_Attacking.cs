using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone_Attacking : MonoBehaviour
{
    public int health = 100;
    public float speed = 3;

    bool up = false;

    public GameObject player;

    private void Awake()
    {
        player.transform.position = new Vector3(-4, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x > player.transform.position.x + 5)
        {
            this.transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else
        {
            if(up)
            {
                this.transform.position += Vector3.up * speed * Time.deltaTime;
                if (this.transform.position.y >= 4)
                    up = false;
            }
            else
            {
                this.transform.position += Vector3.down * speed * Time.deltaTime;
                if (this.transform.position.y <= -4)
                    up = true;
            }
        }

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
