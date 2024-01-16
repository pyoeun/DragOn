using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    public string DragonName;
    [Range(0f,100f)] public int Attack = 0;
    [Range(0f, 100f)] public int Health = 0;
    [Range(0f, 10f)] public float MoveSpeed = 0;
    [Range(0f, 10f)] public float BulletSpeed = 0;
    [Range(0f, 3f)] public float Delay = 0;

    public Color NameColor;
    public string AttackText = "++";
    public string HealthText = "++";
    public string MoveSpeedText = "++";
    public string BulletSpeedText = "++";
    public string DelayText = "++";
    public string Special = "";
}
