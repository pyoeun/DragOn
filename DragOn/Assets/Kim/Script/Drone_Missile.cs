using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone_Missile : MonoBehaviour
{
    public Transform player;
    public GameObject bullet_pre;
    public int health;
    public float speed;
    bool up = false, move = false;

    private void Bullet()
    {
        GameObject Bullet = Instantiate(bullet_pre, transform.position, transform.rotation);
        Vector2 newPos = player.transform.position - transform.position;
        float rotZ = Mathf.Atan2(newPos.y, newPos.x) * Mathf.Rad2Deg;
        Bullet.transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }

    // Start is called before the first frame update
    void Start()
    {
        if(Random.Range(0, 2) == 0) {
            up = true;
        }
        InvokeRepeating("Bullet", 1, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > 7)
        {
            this.transform.position += Vector3.left * speed * Time.deltaTime;
            if(transform.position.x <= 7)
            {
                move = true;
            }
        }
        if(move)
        {
            if (up)
            {
                this.transform.position += Vector3.up * speed * Time.deltaTime;
                if (transform.position.y >= 5)
                {
                    up = false;
                }
            }
            else
            {
                this.transform.position += Vector3.down * speed * Time.deltaTime;
                if (transform.position.y <= -5)
                {
                    up = true;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health -= 10;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
