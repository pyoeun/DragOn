using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Maker : MonoBehaviour
{
    public GameObject[] drons;
    public GameObject bullet_pre;
    public int health;
    public float speed;
    public float rotationSpeed;

    private bool move;

    public float maxTime;
    private float curTime;

    void Pattern1()
    {
        int rand = Random.Range(0, 3);
        GameObject enemy1 = (GameObject)Instantiate(
            drons[rand], new Vector3(transform.position.x - 1, transform.position.y + 1f, 0f), Quaternion.identity);
        GameObject enemy2 = (GameObject)Instantiate(
            drons[rand], new Vector3(transform.position.x - 1, transform.position.y - 1f, 0f), Quaternion.identity);
    }
    private void Pattern2()
    {
        GameObject enemy1 = (GameObject)Instantiate(
                drons[2], new Vector3(transform.position.x - 1, transform.position.y + 2.5f, 0f), Quaternion.identity);
        GameObject enemy2 = (GameObject)Instantiate(
                drons[2], new Vector3(transform.position.x - 1, transform.position.y + 1.25f, 0f), Quaternion.identity);
        GameObject enemy3 = (GameObject)Instantiate(
                drons[2], new Vector3(transform.position.x - 1, transform.position.y, 0f), Quaternion.identity);
        GameObject enemy4 = (GameObject)Instantiate(
                drons[2], new Vector3(transform.position.x - 1, transform.position.y - 1.25f, 0f), Quaternion.identity);
        GameObject enemy5 = (GameObject)Instantiate(
                drons[2], new Vector3(transform.position.x - 1, transform.position.y - 2.5f, 0f), Quaternion.identity);
    }
    private void Pattern3()
    {
        for (int i = 0; i < 15; ++i)
        {
            GameObject Bullet = Instantiate(bullet_pre, transform.position, transform.rotation);
            transform.Rotate(new Vector3(0, 0,  i * 24 * rotationSpeed * Time.deltaTime));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        move = false;
        curTime = 0;
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

        if (curTime > maxTime)
        {
            switch (Random.Range(0, 3))
            {
                case 1:
                    Invoke("Pattern1", 0);
                    Invoke("Pattern1", 2);
                    Invoke("Pattern1", 4);
                    curTime = -4;
                    break;
                case 2:
                    Pattern2();
                    curTime = 0;
                    break;
                case 3:
                    Pattern3();
                    curTime = 0;
                    break;
            }
        }
        else
        {
            curTime += Time.deltaTime;
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
