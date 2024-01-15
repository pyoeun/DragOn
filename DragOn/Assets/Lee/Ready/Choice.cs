using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choice : MonoBehaviour
{
    [SerializeField] GameObject cam;
    GameObject selectedObj; //선택된 오브젝트
    int i = 0;
    static bool D = false;
    static bool S = false;
    static bool B = false;

    private void Start()
    {
        cam.transform.position = new Vector3(0,0,-10);
        selectedObj = null;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) //마우스 클릭시
        {
            { Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //레이캐스트로 오브제트 판단
                RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);
                if (hit.collider != null)
                {
                    selectedObj = hit.collider.gameObject;
                    switch (i)
                    {
                        case 0:
                            {
                                if (selectedObj.name == "SelectEnd" && D == true)
                                {
                                    cam.transform.position = new Vector3(50, 0, -10);
                                    i++;
                                }
                            }
                            break;
                        case 1:
                            {
                                if (selectedObj.name == "SelectEnd" && S == true)
                                {
                                    cam.transform.position = new Vector3(100, 0, -10);
                                    i++;
                                }
                            }
                            break;
                        case 2:
                            {
                                if (selectedObj.name == "SelectEnd" && B == true)
                                {
                                    //씬변경
                                }
                            }
                            break;
                    }
                }
            }
        }
    }
    public static void ChoiceD()
    {
        D = true;
    }
    public static void ChoiceS()
    {
        S = true;
    }
    public static void ChoiceB()
    {
        B = true;
    }
}
