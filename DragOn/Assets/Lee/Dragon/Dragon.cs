using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    public string DragonName = null;



    private void Awake()
    {
        string tmp = this.gameObject.name;
        for (int i = 0; i < tmp.Length - 7; i++)
            this.DragonName += tmp[i];
    }
}
