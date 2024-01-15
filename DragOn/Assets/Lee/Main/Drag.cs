using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Drag : MonoBehaviour
{
    //Drag animation
    [SerializeField] GameObject dragObject;
    GameObject temp1, temp2, temp3, temp4;
    bool isTempReset;

    //DragPos
    public Camera cam;                      //카메라
    Vector2 click_Pos;                      //클릭 좌표
    Vector2 Drag_Pos;                       //드래그 좌표
    bool isDrag;                            //드래그 중인가?
    [SerializeField][Range(0f, 15f)] float minSpeed;         //최소 스피드
    [SerializeField][Range(15f, 30f)] float maxSpeed;        //최대 스피드


    void printCircle(Vector2 start, Vector2 end)
    {
        temp1.transform.position = start;
        temp2.transform.position = new Vector2(Mathf.Lerp(start.x,end.x,0.33f), Mathf.Lerp(start.y, end.y, 0.33f));
        temp3.transform.position = new Vector2(Mathf.Lerp(start.x,end.x,0.66f), Mathf.Lerp(start.y, end.y, 0.66f));
        temp4.transform.position = end;
    }
    private void Start()
    {
        isTempReset = false;
        temp1 = Instantiate(dragObject, new Vector3(0, 10, 0), Quaternion.identity);
        temp2 = Instantiate(dragObject, new Vector3(0, 10, 0), Quaternion.identity);
        temp2.GetComponent<Renderer>().material.color = new UnityEngine.Color(1, 1, 1, 0.8f);
        temp3 = Instantiate(dragObject, new Vector3(0, 10, 0), Quaternion.identity);
        temp3.GetComponent<Renderer>().material.color = new UnityEngine.Color(1, 1, 1, 0.6f);
        temp4 = Instantiate(dragObject, new Vector3(0, 10, 0), Quaternion.identity);
        temp4.GetComponent<Renderer>().material.color = new UnityEngine.Color(1, 1, 1, 0.4f);

        cam.GetComponent<Camera>();
        isDrag = false;
    }
    private void Update()
    {
        if(!isDrag)
        {
            if(!isTempReset)
            {
                temp1.transform.position = temp2.transform.position = temp3.transform.position = temp4.transform.position = new Vector3(0, 10, 0);
                isTempReset = true;
            }
        }
        if (Input.GetMouseButtonDown(0))                    //Drag start
        {
            click_Pos = Input.mousePosition;
            click_Pos = cam.ScreenToWorldPoint(click_Pos);
            isDrag = true;
        }
        if(isDrag)                                          //Draging
        {
            Drag_Pos = Input.mousePosition;
            Drag_Pos = cam.ScreenToWorldPoint(Drag_Pos);
            printCircle(click_Pos, Drag_Pos);
        }
        if(Input.GetMouseButtonUp(0))                       //Drag end
        {
            isDrag = false;
            isTempReset = false;
            float Distance = Vector3.Distance(click_Pos, Drag_Pos);
            if (Distance > 0)
            {
                float Angle = Mathf.Atan2(Drag_Pos.y - click_Pos.y, Drag_Pos.x - click_Pos.x) * Mathf.Rad2Deg;
                if (Angle < 0)
                    Angle = 360 + Angle;
                Distance = Mathf.Min(maxSpeed, Distance);
                Distance = Mathf.Max(minSpeed, Distance);
                if(Angle > 80f && Angle < 280f)
                    shooting.shootBullet(Angle, (int)Distance);
            }
            else
            {
                Distance = Mathf.Min(maxSpeed, Distance);
                Distance = Mathf.Max(minSpeed, Distance);
                Debug.Log(Distance);
                shooting.shootBullet(180, (int)Distance);
            }
        }
    }
}