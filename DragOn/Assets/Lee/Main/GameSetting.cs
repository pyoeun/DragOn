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
        if(nowHelth > MaxHelth)
        {
            nowHelth = MaxHelth;
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
        Bullet.GetComponent<Image>().fillAmount = gameObject.GetComponent<Drag>().k;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(nowHelth);
        if (other.tag == "EnemyBullet" || other.tag == "Enemy")
        {
            if (!hit)
            {
                Health[nowHelth].SetActive(false);
                nowHelth -= 1;
                if (nowHelth <= 0)
                    Die();
                else
                    Hit();
                hit = true;
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
