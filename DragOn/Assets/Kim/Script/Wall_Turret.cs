using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Turret : MonoBehaviour
{
    public GameObject bullet_pre;
    public float maxTime;
    private float curTime;

    private bool rotate;

    private void Bullet()
    {
        GameObject Bullet = Instantiate(bullet_pre, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
    }

    // Start is called before the first frame update
    void Start()
    {
        rotate = false;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 100));
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.eulerAngles.z < 100)
            rotate = true;
        if (transform.eulerAngles.z > 260)
            rotate = false;
        if (rotate)
            transform.Rotate(new Vector3(0, 0, 100 * Time.deltaTime));
        else
            transform.Rotate(new Vector3(0, 0, 100 * Time.deltaTime * -1));

        if(transform.position.x > 6.5f)
            this.transform.position += Vector3.left * 3 * Time.deltaTime;

        if (curTime > maxTime)
        {
            for(float i = 0; i < 10; ++i)
            {
                Invoke("Bullet", (i / 5));
            }
            curTime = 0;
        }
        else
        {
            curTime += Time.deltaTime;
        }
    }
}
