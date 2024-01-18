using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_ShootingDown : MonoBehaviour
{
    public GameObject bullet_pre;

    public float maxTime;
    private float curTime;

    GameObject tmp;
    Transform player;
    private void Awake()
    {
        tmp = GameObject.Find("Dragon");
        player = tmp.GetComponent<Transform>();
    }

    private void Shot()
    {
        GameObject SD = Instantiate(bullet_pre, new Vector3(transform.position.x, transform.position.y - 0.5f, 0), transform.rotation);
        Vector2 newPos = player.transform.position - transform.position;
        float rotZ = Mathf.Atan2(newPos.y, newPos.x) * Mathf.Rad2Deg;
        SD.transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 6.5f)
            this.transform.position += Vector3.left * 3 * Time.deltaTime;

        if (curTime > maxTime)
        {
            Shot();
            curTime = 0;
        }
        else
        {
            curTime += Time.deltaTime;
        }
    }
}
