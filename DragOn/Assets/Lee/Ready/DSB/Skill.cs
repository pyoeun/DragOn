using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public string skillName = null;
    private void Awake()
    {
        string tmp = this.gameObject.name;
        for (int i = 0; i < tmp.Length - 7; i++)
            this.skillName += tmp[i];
    }
}
