using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone_Armored : MonoBehaviour
{
    public int health = 100;
    public float speed = 4;
    public float rotationSpeed = 100f;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));

        if (this.transform.position.x > 11 || this.transform.position.x < -11 || this.transform.position.y > 6 || this.transform.position.y < -6)
        {
            transform.Rotate(new Vector3(0, 0, Random.Range(100, 200) * rotationSpeed * Time.deltaTime));
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

        if (collision.gameObject.tag == "Finish")
        {
        }
    }
}
