using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choice : MonoBehaviour
{
    [SerializeField] GameObject cam;
    GameObject selectedObj; //선택된 오브젝트
    int i = 0;
    private void Start()
    {
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
                    GameObject clickObj = hit.collider.gameObject;
                    selectedObj = clickObj;
                }
            } // 클릭오브젝트
            switch(i)
            {
                case 0:
                    {
                        if (selectedObj.name == "SelectEnd")
                            cam.transform.position = new Vector3(0, 0, -10);

                    }
            }
            
        }
    }
}
