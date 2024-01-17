using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone_Maker : MonoBehaviour
{
    public GameObject[] drons;
    public int health;
    public float speed;
    public float rotationSpeed;

    private bool move;

    void SpawnEnemy()
    {
        GameObject enemy = (GameObject)Instantiate(drons[Random.Range(0, 2)], new Vector3(transform.position.x - 1, transform.position.y, 0f), Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1, 3);
        move = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-1 * speed * Time.deltaTime, 0, 0));
        if (transform.position.x < 9)
        {
            move = true;
        }
        if (move)
        {
            if (transform.position.x > 9 || transform.position.x < 1 || transform.position.y > 4.5f || transform.position.y < -4.5f)
            {
                transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
                transform.Rotate(new Vector3(0, 0, Random.Range(100, 200) * rotationSpeed * Time.deltaTime));
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
