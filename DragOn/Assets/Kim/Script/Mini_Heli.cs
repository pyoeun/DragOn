using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mini_Heli : MonoBehaviour
{
    [SerializeField] [Range(5 ,10)] float circleR; //반지름
    [SerializeField] float deg; //각도
    [SerializeField] float objSpeed; //원운동 속도

    public Transform player;
    public GameObject bullet_pre;
    public float speed;

    public int maxBullet;
    private int bulletCount;
    private bool reroading;

    public float maxReroad;
    private float reroadNum;

    bool isBool = true;

    private void Bullet()
    {
        if (bulletCount < maxBullet)
        {
            GameObject Bullet = Instantiate(bullet_pre, transform.position, transform.rotation);
            Vector2 newPos = player.transform.position - transform.position;
            float rotZ = Mathf.Atan2(newPos.y, newPos.x) * Mathf.Rad2Deg;
            Bullet.transform.rotation = Quaternion.Euler(0, 0, rotZ);
            bulletCount++;
        }
        else
            reroading = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        reroading = false;
        InvokeRepeating("Bullet", 5, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (reroading)
        {
            if(reroadNum < maxReroad)
            {
                reroadNum += Time.deltaTime;
            }
            else
            {
                reroadNum = 0;
                bulletCount = 0;
                reroading = false;
            }
        }
        else
        {
            if(isBool == true)
                deg += Time.deltaTime * objSpeed;
            if(isBool == false)
                deg += Time.deltaTime * objSpeed * -1;

            
            if (deg < 360)
            {
                var rad = Mathf.Deg2Rad * (deg);
                var x = circleR * Mathf.Sin(rad);
                var y = circleR * Mathf.Cos(rad);

                if (deg < 60 && isBool == false)
                    isBool = true;
                if (deg > 120 && isBool == true)
                    isBool = false;

                this.gameObject.transform.position = player.transform.position + new Vector3(x, y);
            }
            else
            {
                deg = 0;
            }
        }

    }
}
