using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class machine_gun : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(new Vector3(0, 0, Random.Range(-45, 45) * rotationSpeed * Time.deltaTime));
        Destroy(gameObject, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
