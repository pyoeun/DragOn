using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choice : MonoBehaviour
{
    [SerializeField] GameObject cam;
    GameObject selectedObj; //���õ� ������Ʈ
    int i = 0;
    private void Start()
    {
        selectedObj = null;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) //���콺 Ŭ����
        {
            { Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //����ĳ��Ʈ�� ������Ʈ �Ǵ�
                RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);
                if (hit.collider != null)
                {
                    GameObject clickObj = hit.collider.gameObject;
                    selectedObj = clickObj;
                }
            } // Ŭ��������Ʈ
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
