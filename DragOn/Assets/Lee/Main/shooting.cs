using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class shooting : MonoBehaviour
{
    [SerializeField] GameObject shootObj;
    [SerializeField] GameObject ShootPoint;
    static float angle;
    static int distance;
    static bool Shoot = false;
    public static void shootBullet(float _angle,int _distance)
    {
        Shoot = true;
        angle = _angle;
        distance = _distance;
    }
    private void Update()
    {
        if(Shoot)
        {
            Quaternion v3Rotation = Quaternion.Euler(0f, 0f, angle);
            Vector3 v3Direction = Vector3.left;
            Vector3 v3RotatedDirection = v3Rotation * v3Direction;

            GameObject bullet = Instantiate(shootObj, ShootPoint.transform.position, Quaternion.Euler(new Vector3(0, 0, angle)));
            bullet.GetComponent<Rigidbody2D>().velocity = v3RotatedDirection * distance * 2.5f;
            Destroy(bullet, 2.0f);
            Shoot = false;
        }
    }
}
