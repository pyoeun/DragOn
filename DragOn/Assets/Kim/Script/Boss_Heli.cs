using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Heli : MonoBehaviour
{
    private float spTime;
    private int spCount;
    SpriteRenderer spriteRenderer;
    [SerializeField] Sprite[] sp;

    public Transform player;
    public Transform bullet_pos1;
    public Transform bullet_pos2;
    public GameObject bullet_pre;
    public float speed;

    private int patternCount;
    private bool reroading;
    public float maxReroad;
    private float reroadNum;

    public float maxTime;
    private float curTime;

    public float maxBulletT;
    private float curBulletT;

    bool pattern2;
    bool up;

    bool pattern3;

    bool tmp1 = true;
    bool tmp2 = false;
    private void BulletP1()
    {
        GameObject bullet1 = Instantiate(bullet_pre, bullet_pos1.position, bullet_pos1.rotation);
        GameObject bullet2 = Instantiate(bullet_pre, bullet_pos2.position, bullet_pos2.rotation);
    }
    private void BulletP2()
    {
        GameObject bullet = Instantiate(bullet_pre, transform.position, transform.rotation);
        bullet.transform.Rotate(new Vector3(0, 0, 180));
    }
    private void BulletP3()
    {
        GameObject Bullet = Instantiate(bullet_pre, transform.position, transform.rotation);
        Vector2 newPos = player.transform.position - transform.position;
        float rotZ = Mathf.Atan2(newPos.y, newPos.x) * Mathf.Rad2Deg;
        Bullet.transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }
    private void Pattern1()
    {
        for (float i = 0; i < 20; ++i)
        {
            Invoke("BulletP1", (i / 10));
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        spTime = 0.0f;
        spCount = 0;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        bullet_pos1.rotation = Quaternion.Euler(new Vector3(0, 0, 100));
        bullet_pos2.rotation = Quaternion.Euler(new Vector3(0, 0, 260));

        patternCount = 0;
        curTime = 0;
        curBulletT = 0;
        reroading = false;

        pattern2 = false;
        up = false;

        pattern3 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (spTime > 0.05f)
        {
            spriteRenderer.sprite = sp[spCount];
            spCount++;
            spCount %= sp.Length;
            spTime = 0;
        }
        else
        {
            spTime += Time.deltaTime;
        }

        if (bullet_pos1.eulerAngles.z < 100)
            tmp1 = true;
        if (bullet_pos1.eulerAngles.z > 260)
            tmp1 = false;
        if(tmp1)
            bullet_pos1.Rotate(new Vector3(0, 0, 100 * Time.deltaTime));
        else
            bullet_pos1.Rotate(new Vector3(0, 0, 100 * Time.deltaTime * -1));

        if (bullet_pos2.eulerAngles.z < 100)
            tmp2 = true;
        if (bullet_pos2.eulerAngles.z > 260)
            tmp2 = false;
        if (tmp2)
            bullet_pos2.Rotate(new Vector3(0, 0, 100 * Time.deltaTime));
        else
            bullet_pos2.Rotate(new Vector3(0, 0, 100 * Time.deltaTime * -1));

        if (reroading)
        {
            if(transform.position.x < 8)
            {
                this.transform.position += Vector3.right * speed * Time.deltaTime;
            }
            else
            {
                if (reroadNum < maxReroad)
                {
                    reroadNum += Time.deltaTime;
                }
                else
                {
                    reroadNum = 0;
                    reroading = false;
                }
            }
            
        }
        else
        {
            if(pattern2)
            {
                if (up)
                {
                    this.transform.position += Vector3.up * speed * Time.deltaTime;
                    if (transform.position.y > 5)
                    {
                        up = false;
                    }
                }
                else
                {
                    this.transform.position += Vector3.down * speed * Time.deltaTime;
                    if (transform.position.y < -5)
                    {
                        pattern2 = false;
                    }
                }

                if (curBulletT > maxBulletT)
                {
                    BulletP2();
                    curBulletT = 0;
                }
                else
                {
                    curBulletT += Time.deltaTime;
                }
            }
            else if(pattern3)
            {
                this.transform.position += Vector3.left * speed * Time.deltaTime;
                if (curBulletT > maxBulletT)
                {
                    BulletP3();
                    curBulletT = 0;
                }
                else
                {
                    curBulletT += Time.deltaTime;
                }
                if (transform.position.x < -10)
                {
                    transform.position = new Vector3(10, 2, 0);
                    pattern3 = false;
                }
            }
            else
            {
                if (transform.position.x > 4)
                {
                    this.transform.position += Vector3.left * speed * Time.deltaTime;
                }
                if(transform.position.y < 2)
                {
                    this.transform.position += Vector3.up * speed * Time.deltaTime;
                }

                if (curTime > maxTime)
                {
                    curTime = 0;
                    switch (Random.Range(0, 3))
                    {
                        case 0:
                            Pattern1();
                            break;
                        case 1:
                            pattern2 = true;
                            up = true;
                            break;
                        case 2:
                            pattern3 = true;
                            break;
                    }
                    patternCount++;
                    if(patternCount >= 2)
                    {
                        patternCount = 0;
                        reroading = true;
                    }
                }
                else
                {
                    curTime += Time.deltaTime;
                }
            }
        }
    }
}
