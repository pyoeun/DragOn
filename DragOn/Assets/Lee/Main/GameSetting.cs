using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSetting : MonoBehaviour
{
    private Animator ani;
    [SerializeField] GameObject[] Dragons;
    [SerializeField] GameObject Bullet;
    [SerializeField] GameObject Bullet_Back;
    [SerializeField] GameObject[] Health;

    bool Hit = false;
    GameObject Dragon;
    public Dragon d;
    float angleTemp;
    int distanceTemp;
    int MaxHelth;
    int nowHelth;
    private void Awake()
    {
        Dragon = Instantiate(Dragons[MainSingleton.dragon - 1],transform);
        ani = Dragon.GetComponent<Animator>();
        d = Dragon.GetComponent<Dragon>();

        MaxHelth = d.Health;
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

        Bullet.GetComponent<Image>().fillAmount = gameObject.GetComponent<Drag>().k;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "EnemyBullet")
        {
            nowHelth--;
            if (nowHelth <= 0)
                Die();
            else
                Hit();
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
