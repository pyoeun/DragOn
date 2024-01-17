using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone_Armored : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;

    private float spTime;
    private int spCount;
    SpriteRenderer spriteRenderer;
    [SerializeField] Sprite[] sp;

    private void Start()
    {
        spTime = 0.0f;
        spCount = 0;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        transform.Rotate(new Vector3(0, 0, Random.Range(100, 200) * rotationSpeed * Time.deltaTime));
    }

    // Update is called once per frame
    void Update()
    {
        if (spTime > 0.1f)
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

        this.transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));

        if (this.transform.position.x > 10 || this.transform.position.x < -9 || this.transform.position.y > 5 || this.transform.position.y < -5)
        {
            this.transform.Translate(new Vector3(-1 * speed * Time.deltaTime, 0, 0));
            transform.Rotate(new Vector3(0, 0, Random.Range(100, 200) * rotationSpeed * Time.deltaTime));
        }
    }
}
