using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public string[] EnemyObjs;
    public GameObject[] Enemys;

    void SpawnEnemy()
    {
        //Random.Range(0, 8)
        float randomY = Random.Range(-4, 4);
        GameObject enemy = (GameObject)Instantiate(Enemys[11], new Vector3(10, randomY, 0f), Quaternion.identity);
    }
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("SpawnEnemy", 1, 3);
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
