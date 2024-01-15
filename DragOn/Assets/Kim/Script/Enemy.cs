using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public float speed = 3;

   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += Vector3.left * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            health -= 30;
            if(health <= 0)
            {
                gameObject.SetActive(false);
            }
        }
        if (collision.gameObject.tag == "Finish")
        {
            gameObject.SetActive(false);
        }
    }
}
