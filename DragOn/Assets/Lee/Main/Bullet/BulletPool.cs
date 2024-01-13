using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool instance;
    private GameObject poolingPrefab;
    private Queue<Bullet> poolingQueue = new Queue<Bullet>();
    private void Awake()
    {
        instance = this;
    }
}
