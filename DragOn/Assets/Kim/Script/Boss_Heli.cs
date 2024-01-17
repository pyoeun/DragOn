using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Heli : MonoBehaviour
{
    public GameObject bullet_pre;
    public Transform player;
    public int health;
    public float speed;

    private bool reroading;
    public float maxReroad;
    private float reroadNum;

    private void Bullet()
    {


    }
    private void Pattern1()
    {
        float curBT = 0, maxBT = 0.2f;
        int bulletCount = 0;
        while(bulletCount < 30)
        {
            if (curBT > maxBT)
            {
                GameObject Bullet1 = Instantiate(bullet_pre, new Vector3(transform.position.x, transform.position.y + 0.5f, 0), transform.rotation);
                GameObject Bullet2 = Instantiate(bullet_pre, new Vector3(transform.position.x, transform.position.y - 0.5f, 0), transform.rotation);
                
            }
            else
                curBT += Time.deltaTime;
        }

    }
    private void Pattern2()
    {

    }
    private void Pattern3()
    {

    }
    private void Pattern4()
    {
        switch (Random.Range(0, 4))
        {
            case 1:
                Pattern1();
                break;
            case 2:
                Pattern2();
                break;
            case 3:
                Pattern3();
                break;
        }
        reroading = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        reroading = false;
        InvokeRepeating("Pattern1", 0, 4);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (reroading)
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
        else
        {
            
        }
    }
}
