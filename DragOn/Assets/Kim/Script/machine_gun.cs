using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class machine_gun : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));

        if (transform.position.x < -10)
            Destroy(gameObject);
        if (transform.position.y < -6f || transform.position.y > 6f)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
