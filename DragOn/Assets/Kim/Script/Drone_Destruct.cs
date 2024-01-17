using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone_Destruct : MonoBehaviour
{
    public float speed;

    private float spTime;
    private int spCount;
    SpriteRenderer spriteRenderer;
    [SerializeField] Sprite[] sp;

    // Update is called once per frame
    private void Start()
    {
        spTime = 0.0f;
        spCount = 0;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (spTime > 0.05f)
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

        this.transform.position += Vector3.left * speed * Time.deltaTime;

        if (this.transform.position.x < -12)
        {
            Destroy(gameObject);
        }

    }
}
