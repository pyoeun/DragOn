using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Missile : MonoBehaviour
{
    public GameObject missile;
    public float maxTime;
    private float curTime;

    private void summonMissile()
    {
        GameObject enemy1 = (GameObject)Instantiate(
            missile, new Vector3(transform.position.x - 1, transform.position.y + 0.5f, 0f), Quaternion.identity);
        GameObject enemy2 = (GameObject)Instantiate(
            missile, new Vector3(transform.position.x - 1, transform.position.y - 0.5f, 0f), Quaternion.identity);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 6.5f)
            this.transform.position += Vector3.left * 3 * Time.deltaTime;

        if (curTime > maxTime)
        {
            summonMissile();
            curTime = 0;
        }
        else
        {
            curTime += Time.deltaTime;
        }
    }
}
