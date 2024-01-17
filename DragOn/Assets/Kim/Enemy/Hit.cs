using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    public int Health;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Health -= collision.gameObject.GetComponent<Bullet>().Damage;
            if (Health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
