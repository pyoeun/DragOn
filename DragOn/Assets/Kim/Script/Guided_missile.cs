using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guided_missile : MonoBehaviour
{
    public float speed;

    GameObject tmp;
    Transform player;
    private void Awake()
    {
        tmp = GameObject.Find("Dragon");
        player = tmp.GetComponent<Transform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPos = player.transform.position - transform.position;
        float rotZ = Mathf.Atan2(newPos.y, newPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
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
