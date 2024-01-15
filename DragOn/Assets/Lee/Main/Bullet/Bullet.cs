using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public float power;
    Bullet(float _damage,float _power)
    {
        damage = _damage;
        power = _power;
    }
}
