using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public string[] EnemyObjs;
    public GameObject Enemy;

    void SpawnEnemy()
    {
        float randomY = Random.RandomRange(-4f, 4f);
        GameObject enemy = (GameObject)Instantiate(Enemy, new Vector3(10, randomY, 0f), Quaternion.identity);
    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 2, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
