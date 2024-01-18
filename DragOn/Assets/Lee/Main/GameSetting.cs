using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Unity.Burst.Intrinsics.X86.Avx;

public class GameSetting : MonoBehaviour
{
    private Animator ani;
    [SerializeField] GameObject[] Dragons;
    [SerializeField] GameObject Bullet;
    [SerializeField] GameObject Bullet_Back;
    [SerializeField] GameObject[] Health;

    public bool Suild = false;

    float time;
    float Ttime;
    public bool hit = false;
    GameObject Dragon;
    public Dragon d;
    float angleTemp;
    int distanceTemp;
    int MaxHelth;
    public int nowHelth;
    bool tmp;
    float sTime = 0.0f;
    public bool die = false;
    private void Awake()
    {
        tmp = false;
        time = 0.0f;
        Ttime = 0.0f;
        Dragon = Instantiate(Dragons[MainSingleton.dragon - 1],transform);
        ani = Dragon.GetComponent<Animator>();
        d = Dragon.GetComponent<Dragon>();
        MaxHelth = d.Health;
        nowHelth = d.Health;
        for(int i = 0; i < 5; i++)
        {
            Health[i].SetActive(false);
        }
        for(int i = 0; i < MaxHelth; i++)
        {
            Health[i].SetActive(true);
        }
        Bullet.GetComponent<Image>().sprite = d.Bullet.GetComponent<SpriteRenderer>().sprite;
        Bullet_Back.GetComponent<Image>().sprite = d.Bullet.GetComponent<SpriteRenderer>().sprite;
        Bullet_Back.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.2f);
        this.gameObject.GetComponent<Drag>().Delay = d.Delay;
        this.gameObject.GetComponent<Move>().moveSpeed = d.MoveSpeed;
        this.gameObject.GetComponent<shooting>().BulletSpeed = d.BulletSpeed;
        this.gameObject.GetComponent<shooting>().shootObj = d.Bullet;
    }
    private void Update()
    {

        if (Suild)
        {
            sTime += Time.deltaTime;
            if (sTime > 3)
            {
                sTime = 0.0f;
                Suild = false;
            }
        }
        if (hit)
        {
            time += Time.deltaTime;
            Ttime += Time.deltaTime;
            if (Ttime > 0.3f)
            {
                tmp = !tmp;
                Ttime = 0.0f;
            }
            if (tmp)
                Dragon.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, 0.6f);
            else
                Dragon.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
            if (time > 2f)
            {
                tmp = true;
                Ttime = 0.0f;
                time = 0.0f;
                hit = false;
                Dragon.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
            }
        }
        if (nowHelth > MaxHelth)
        {
            nowHelth = MaxHelth;
        }
        for (int i = 0; i < 5; i++)
        {
            Health[i].SetActive(false);
        }
        for (int i = 0; i < nowHelth; i++)
        {
            Health[i].SetActive(true);
        }
        Bullet.GetComponent<Image>().fillAmount = gameObject.GetComponent<Drag>().k;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "EnemyBullet" || other.tag == "Enemy")
        {
            if(!Suild)
            {
                if (!hit)
                {
                    nowHelth -= 1;
                    Debug.Log(nowHelth);
                    if (nowHelth == 0)
                    {
                        Die();
                        die = true;
                    }
                    else
                        Hit();
                    hit = true;
                }
            }
        }
    }
    public void Shooting(float _angle, int _distance)
    {
        ani.SetBool("isAttack", true);
        angleTemp = _angle;
        distanceTemp = _distance;
    }
    public void Shoot()
    {
        gameObject.GetComponent<shooting>().shootBullet(angleTemp, distanceTemp);
    }
    public void Hit()
    {
        ani.SetBool("isHit", true);
    }
    public void Die()
    {
        ani.SetBool("isDie", true);
    }
    public void Dash()
    {
        ani.SetBool("isDash", true);
    }
}
