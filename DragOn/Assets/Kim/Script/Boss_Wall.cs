using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Wall : MonoBehaviour
{
    public GameObject drone;
    public GameObject turret;
    public GameObject shootingdown;
    public GameObject missile;

    // Start is called before the first frame update
    void Start()
    {
        GameObject enemy1 = (GameObject)Instantiate(drone, new Vector3(9, 3.75f, 0f), Quaternion.identity);
        GameObject enemy2 = (GameObject)Instantiate(turret, new Vector3(9, 1.25f, 0f), Quaternion.identity);
        GameObject enemy3 = (GameObject)Instantiate(shootingdown, new Vector3(9, -1.25f, 0f), Quaternion.identity);
        GameObject enemy4 = (GameObject)Instantiate(missile, new Vector3(9, -3.75f, 0f), Quaternion.identity);
        transform.position = new Vector3(10, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > 7.5f)
        {
            this.transform.position += Vector3.left * 3 * Time.deltaTime;
        }
    }
}
