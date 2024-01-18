using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] Enemys;

    private int maxEnemy;
    private int bossNum;

    private float curTime;
    private float maxTime;
    private bool boss;

    private void SpawnEnemy()
    {
        //Random.Range(0, 8)
        float randomY = Random.Range(-4, 4);
        GameObject enemy = (GameObject)Instantiate(Enemys[Random.Range(0, maxEnemy)], new Vector3(10, randomY, 0f), Quaternion.identity);
    }
    private void SpawnBoss()
    {
        float randomY = Random.Range(-4, 4);
        GameObject enemy = (GameObject)Instantiate(Enemys[bossNum], new Vector3(10, randomY, 0f), Quaternion.identity);
    }

    private void Pattern1()
    {
        maxEnemy = 3;
        bossNum = 8;
        for(int i = 0; i < 10; ++i)
        {
            Invoke("SpawnEnemy", i * 3);
        }
    }
    private void Pattern2()
    {
        maxEnemy = 5;
        bossNum = 9;
        for (int i = 0; i < 10; ++i)
        {
            Invoke("SpawnEnemy", i * 3);
        }
    }
    private void Pattern3()
    {
        maxTime = 40;
        maxEnemy = 7;
        bossNum = 10;
        for (int i = 0; i < 13; ++i)
        {
            Invoke("SpawnEnemy", i * 3);
        }
    }
    private void Pattern4()
    {
        maxTime = 40;
        maxEnemy = 8;
        bossNum = 11;
        for (int i = 0; i < 13; ++i)
        {
            Invoke("SpawnEnemy", i * 3);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        maxEnemy = 0;
        bossNum = 0;
        curTime = 0;
        maxTime = 30;
        boss = false;
        //InvokeRepeating("SpawnEnemy", 1, 3);
        //SpawnEnemy();
        Pattern4();
    }

    // Update is called once per frame
    void Update()
    {
        if (curTime > maxTime && boss == false)
        {
            boss = true;
            SpawnBoss();
        }
        else if (curTime <= maxTime)
        {
            curTime += Time.deltaTime;
        }
    }
}
