using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    public string DragonName;
    public GameObject Bullet;
    [Range(0f,100f)] public int Attack = 0;
    [Range(0f, 100f)] public int Health = 0;
    [Range(0f, 20f)] public float MoveSpeed = 0;
    [Range(0f, 10f)] public float BulletSpeed = 0;
    [Range(0f, 3f)] public float Delay = 0;

    public Color NameColor;
    public string AttackText = "++";
    public string HealthText = "++";
    public string MoveSpeedText = "++";
    public string BulletSpeedText = "++";
    public string DelayText = "++";
    public string Special = "";
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void Reani()
    {
        animator.SetBool("isAttack", false);
        animator.SetBool("isHit", false);
    }
    public void Shooting()
    {
        GetComponentInParent<GameSetting>().Shoot();
    }
}
