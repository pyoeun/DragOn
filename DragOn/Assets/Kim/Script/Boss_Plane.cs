using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Plane : MonoBehaviour
{
    public GameObject bullet_pre;
    public GameObject missile_pre;
    public float speed;

    public float maxTime;
    private float curTime;

    private bool pattern2;
    private int pattern2Count;

    private bool pattern3;
    private bool pattern3Move;
    private bool pattern3Left;

    public bool pattern4;
    public float pattern4Time;

    GameObject tmp;
    Transform player;
    private void Awake()
    {
        tmp = GameObject.Find("Dragon");
        player = tmp.GetComponent<Transform>();
    }
    private void BulletP1()
    {
        GameObject Bullet = Instantiate(bullet_pre, transform.position, transform.rotation);
        Vector2 newPos = player.transform.position - transform.position;
        float rotZ = Mathf.Atan2(newPos.y, newPos.x) * Mathf.Rad2Deg;
        Bullet.transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }
    private void BulletP3()
    {
        GameObject Bullet = Instantiate(missile_pre, transform.position, transform.rotation);
        Vector2 newPos = player.transform.position - transform.position;
        float rotZ = Mathf.Atan2(newPos.y, newPos.x) * Mathf.Rad2Deg;
        Bullet.transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }
    private void BulletP4()
    {
        GameObject enemy1 = (GameObject)Instantiate(
                missile_pre, new Vector3(transform.position.x - 1, transform.position.y + Random.Range(-5.0f, 5.0f), 0f), Quaternion.identity);
        enemy1.transform.Rotate(new Vector3(0, 0, 180));
        GameObject enemy2 = (GameObject)Instantiate(
                missile_pre, new Vector3(transform.position.x - 1, transform.position.y + Random.Range(-5.0f, 5.0f), 0f), Quaternion.identity);
        enemy2.transform.Rotate(new Vector3(0, 0, 180));
        GameObject enemy3 = (GameObject)Instantiate(
                missile_pre, new Vector3(transform.position.x - 1, transform.position.y + Random.Range(-5.0f, 5.0f), 0f), Quaternion.identity);
        enemy3.transform.Rotate(new Vector3(0, 0, 180));
        GameObject enemy4 = (GameObject)Instantiate(
                missile_pre, new Vector3(transform.position.x - 1, transform.position.y + Random.Range(-5.0f, 5.0f), 0f), Quaternion.identity);
        enemy4.transform.Rotate(new Vector3(0, 0, 180));
        GameObject enemy5 = (GameObject)Instantiate(
                missile_pre, new Vector3(transform.position.x - 1, transform.position.y + Random.Range(-5.0f, 5.0f), 0f), Quaternion.identity);
        enemy5.transform.Rotate(new Vector3(0, 0, 180));
    }
    private void Pattern1()
    {
        for (float i = 1; i < 4; ++i)
            Invoke("BulletP1", (i / 10));
    }
    private void Pattern3()
    {
        for (float i = 1; i < 5; ++i)
            Invoke("BulletP3", 1 + (i / 5));
    }
    private void Pattern4()
    {
        for (float i = 1; i < 4; ++i)
            Invoke("BulletP4", i);
    }

    // Start is called before the first frame update
    void Start()
    {
        pattern2 = false;
        pattern2Count = 0;
        pattern3 = false;
        pattern3Move = false;
        pattern3Left = false;
        pattern4 = false;
        pattern4Time = 0;
        curTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (pattern2)
        {
            if (transform.position.x > -10)
            {
                transform.position += Vector3.left * 2 * speed * Time.deltaTime;
                if(transform.position.x < -10)
                {
                    transform.position = new Vector3(10, Random.Range(-4.0f, 4.0f), 0);
                    ++pattern2Count;
                    if(pattern2Count > 3)
                    {
                        pattern2Count = 0;
                        pattern2 = false;
                    }
                }
            }
        }
        else if (pattern3)
        {
            if (pattern3Move)
            {
                if(pattern3Left)
                {
                    transform.position += Vector3.left * 2 * speed * Time.deltaTime;
                }
                else
                {
                    transform.position += Vector3.right * 2 * speed * Time.deltaTime;
                }
                if (transform.position.x > 10 || transform.position.x < -10)
                {
                    pattern3 = false;
                    pattern3Left = false;
                    pattern3Move = false;
                    transform.position = new Vector3(10, 0, 0);
                }
            }
            else
            {
                transform.position += Vector3.down * speed * Time.deltaTime;
                if (transform.position.y < -6)
                {
                    pattern3Move = true;
                    if (Random.Range(0, 2) == 0)
                    {
                        pattern3Left = true;
                        transform.position = new Vector3(9, 5, 0);
                    }
                    else
                        transform.position = new Vector3(-9, -5, 0);
                }
            }
        }
        else if (pattern4)
        {
            if (pattern4Time > 6)
            {
                pattern4Time = 0;
                pattern4 = false;
            }
            else
            {
                pattern4Time += Time.deltaTime;
            }
            if (transform.position.x < 10)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
                if(transform.position.x > 10)
                {
                    Pattern4();
                    transform.position = new Vector3(10, Random.Range(-4.0f, 4.0f), 0);
                    
                }
            }
        }
        else
        {
            if (transform.position.x > 9)
                this.transform.position += Vector3.left * speed * Time.deltaTime;
            if (transform.position.x > player.position.x + 8)
            {
                this.transform.position += Vector3.left * speed * Time.deltaTime;
            }
            if (transform.position.x < player.position.x + 6)
            {
                this.transform.position += Vector3.right * speed * Time.deltaTime;
            }
            if (transform.position.y < player.position.y)
            {
                this.transform.position += Vector3.up * speed * Time.deltaTime;
            }
            if (transform.position.y > player.position.y)
            {
                this.transform.position += Vector3.down * speed * Time.deltaTime;
            }

            if (curTime > maxTime)
            {
                curTime = 0;
                switch (Random.Range(0, 4))
                {
                    case 0:
                        Invoke("Pattern1", 0f);
                        Invoke("Pattern1", 1f);
                        Invoke("Pattern1", 2f);
                        Invoke("Pattern1", 3f);
                        Invoke("Pattern1", 4f);
                        curTime -= 4;
                        break;
                    case 1:
                        pattern2 = true;
                        break;
                    case 2:
                        pattern3 = true;
                        Pattern3();
                        break;
                    case 3:
                        curTime -= 2;
                        pattern4 = true;
                        break;
                }
            }
            else
            {
                curTime += Time.deltaTime;
            }
        }
    }
}
