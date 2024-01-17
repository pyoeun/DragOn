using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone_Armored : MonoBehaviour
{
    public int health;
    public float speed;
    public float rotationSpeed;

    private void Start()
    {
        transform.Rotate(new Vector3(0, 0, Random.Range(100, 200) * rotationSpeed * Time.deltaTime));
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));

        if (this.transform.position.x > 10 || this.transform.position.x < -9 || this.transform.position.y > 5 || this.transform.position.y < -5)
        {
            this.transform.Translate(new Vector3(-1 * speed * Time.deltaTime, 0, 0));
            transform.Rotate(new Vector3(0, 0, Random.Range(100, 200) * rotationSpeed * Time.deltaTime));
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
