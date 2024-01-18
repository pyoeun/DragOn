using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mini_Plane : MonoBehaviour
{
    public GameObject bullet_pre;
    public int health;
    public float speed;

    public float maxtime;
    private float curtime;

    GameObject tmp;
    Transform player;
    private void Awake()
    {
        tmp = GameObject.Find("Dragon");
        player = tmp.GetComponent<Transform>();
    }

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
        curtime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 8)
        {
            this.transform.position += Vector3.left * speed * Time.deltaTime;
        }

        curtime += Time.deltaTime;
        if (curtime >= maxtime)
        {
            if (transform.position.x > -10)
            {
                transform.position += Vector3.left * speed * 3 * Time.deltaTime;
            }
            else
            {
                transform.position = new Vector3(10, Random.Range(-4, 4), 0);
                Bullet();
                curtime = 0;
            }
        }
    }
}
