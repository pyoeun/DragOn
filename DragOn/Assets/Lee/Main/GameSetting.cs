using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetting : MonoBehaviour
{
    [SerializeField] GameObject[] Dragons;
    private void Awake()
    {
        Instantiate(Dragons[MainSingleton.dragon - 1],transform);
    }
}
