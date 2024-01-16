using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone_Gun : MonoBehaviour
{
    public GameObject bullet_pre;
    public Transform player;
    public int health;
    public float speed;

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
        InvokeRepeating("Bullet", 1, 0.25f);
    }
    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > 6)
        {
            this.transform.position += Vector3.left * speed * Time.deltaTime;
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
