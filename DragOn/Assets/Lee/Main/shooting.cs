using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public GameObject shootObj;
    [SerializeField] GameObject ShootPoint;
    static float angle;
    static int distance;
    static bool Shoot = false;
    public float BulletSpeed;
    public void shootBullet(float _angle, int _distance)
    {
        Shoot = true;
        angle = _angle;
        distance = _distance;
    }
    private void Update()
    {
        if (Shoot)
        {
            Quaternion v3Rotation = Quaternion.Euler(0f, 0f, angle);
            Vector3 v3Direction = Vector3.left;
            Vector3 v3RotatedDirection = v3Rotation * v3Direction;
            distance = Mathf.Min(distance, 13);
            GameObject bullet = Instantiate(shootObj, ShootPoint.transform.position, Quaternion.Euler(new Vector3(0, 0, angle)));
            bullet.GetComponent<Rigidbody2D>().velocity = v3RotatedDirection * distance * BulletSpeed * 3;
            Destroy(bullet, 2.0f);
            this.gameObject.GetComponent<GameSetting>().Shoot();
            Shoot = false;
        }
    }
}