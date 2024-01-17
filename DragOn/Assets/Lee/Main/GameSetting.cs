using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetting : MonoBehaviour
{
    private Animator ani;
    [SerializeField] GameObject[] Dragons;
    GameObject Dragon;
    Dragon d;
    float angleTemp;
    int distanceTemp;
    private void Awake()
    {
        Dragon = Instantiate(Dragons[MainSingleton.dragon - 1],transform);
        ani = Dragon.GetComponent<Animator>();
        d = Dragon.GetComponent<Dragon>();

        this.gameObject.GetComponent<Drag>().Delay = d.Delay;
        this.gameObject.GetComponent<Move>().moveSpeed = d.MoveSpeed;
        this.gameObject.GetComponent<shooting>().BulletSpeed = d.BulletSpeed;
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
