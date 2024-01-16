using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone_Maker : MonoBehaviour
{
    public GameObject[] drons;
    public int health = 150;
    public float speed = 3;
    public float rotationSpeed = 100f;

    void SpawnEnemy()
    {
        float randomY = Random.Range(-4, 4);
        GameObject enemy = (GameObject)Instantiate(drons[Random.Range(0, 2)], new Vector3(transform.position.x - 1, transform.position.y, 0f), Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));

        if (this.transform.position.x > 10 || this.transform.position.x < 0 || this.transform.position.y > 4.5f || this.transform.position.y < -4.5f)
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
