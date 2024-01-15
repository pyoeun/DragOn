using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choice_Dragon : MonoBehaviour
{
    [SerializeField]
    GameObject[] dragonArr = new GameObject[5];
    [SerializeField]
    Transform spawnTrans;
    [SerializeField]
    float distance;
    private void Start()
    {
        float temp = -distance * 2;
        
        for(int i = 0; i < dragonArr.Length; i++)
        {
            GameObject t = Instantiate(dragonArr[i], spawnTrans);
            t.transform.position = new Vector3(temp, spawnTrans.transform.position.y);
            temp += distance;
        }
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) //���콺 Ŭ����
        {
            GameObject selectedObj = null;
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //����ĳ��Ʈ�� ������Ʈ �Ǵ�
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);
            if (hit.collider != null)
            {
                selectedObj = hit.collider.gameObject;
                if (selectedObj.tag == "Dragon")
                {
                    for (int i = 0; i < dragonArr.Length; i++)
                    {
                        if (selectedObj == dragonArr[i])
                            MainSingleton.dragon = i + 1;
                    }
                    Choice.ChoiceD();
                }
            }
        }
    }
}
