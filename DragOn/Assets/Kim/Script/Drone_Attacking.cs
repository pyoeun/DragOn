using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone_Attacking : MonoBehaviour
{
    public GameObject bullet_pre;
    public Transform player;
    public float speed;
    bool up;

    private float spTime;
    private int spCount;
    SpriteRenderer spriteRenderer;
    [SerializeField] Sprite[] sp;

    private void Bullet()
    {
        GameObject Bullet = Instantiate(bullet_pre, transform.position, transform.rotation);
        Vector2 newPos = player.transform.position - transform.position;
        float rotZ = Mathf.Atan2(newPos.y, newPos.x) * Mathf.Rad2Deg;
        Bullet.transform.rotation = Quaternion.Euler(0, 0, rotZ);
        Bullet.transform.position = new Vector3(Bullet.transform.position.x, Bullet.transform.position.y - 0.25f, 0);
    }

    private void Awake()
    {
        int rand = Random.Range(0, 2);
        if (rand == 0)
            up = false;
        else
            up = true;

    }

    private void Start()
    {
        spTime = 0.0f;
        spCount = 0;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        InvokeRepeating("Bullet", 1, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(spTime > 0.1f)
        {
            spriteRenderer.sprite = sp[spCount];
            spCount++;
            spCount %= sp.Length;
            spTime = 0;
        }
        else
        {
            spTime += Time.deltaTime;
        }

        if (this.transform.position.x > player.transform.position.x + 7)
        {
            this.transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if (this.transform.position.x <= player.transform.position.x + 5)
        {
            this.transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if (up)
        {
            this.transform.position += Vector3.up * speed * Time.deltaTime;
            if (this.transform.position.y >= 4)
                up = false;
        }
        else
        {
            this.transform.position += Vector3.down * speed * Time.deltaTime;
            if (this.transform.position.y <= -4)
                up = true;
        }




    }

}
