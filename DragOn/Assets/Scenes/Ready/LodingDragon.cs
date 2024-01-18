using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LodingDragon : MonoBehaviour
{
    [SerializeField] Text loding; 
    GameObject dragon;
    [SerializeField] GameObject[] dragon_re;
    float time = 0.0f;
    int i = 0;
    private void Awake()
    {
        time = 0.0f;
        dragon = dragon_re[MainSingleton.dragon - 1];
        Instantiate(dragon,transform);
    }
    private void Update()
    {
        time += Time.deltaTime;
        if(time > 0.3f)
        {
            if (i == 0) loding.text = "Loding.";
            if (i == 1) loding.text = "Loding..";
            if (i == 2) loding.text = "Loding...";
            i++;
            i = i % 3;
            time = 0.0f;
        }
    }
}
