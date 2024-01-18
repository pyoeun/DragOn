using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject missile_pre;
    public GameObject guided_missile_pre;
    public GameObject machine_gun_pre;

    GameObject[] missile;
    GameObject[] guided_missile;
    GameObject[] machine_gun;

    GameObject[] targetPool;

    private void Awake()
    {
        missile = new GameObject[10];
        guided_missile = new GameObject[10];
        machine_gun = new GameObject[45];
    }
    

    public GameObject MakeObj(string type)
    {
        switch (type)
        {
            case "missile":
                targetPool = missile;
                break;
            case "guided_missile":
                targetPool = guided_missile;
                break;
            case "machine_gun":
                targetPool = machine_gun;
                break;
        }

        for (int index = 0; index < targetPool.Length; index++)
        {
            if(index == targetPool.Length - 1 && targetPool[index].activeSelf)
            {
                return null;
            }
            if (!targetPool[index].activeSelf)
            {
                targetPool[index].SetActive(true);
                return targetPool[index];
            }
        }

        return null;
    }
}
