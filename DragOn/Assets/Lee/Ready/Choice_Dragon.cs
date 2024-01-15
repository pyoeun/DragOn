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
        if (Input.GetMouseButtonDown(0)) //마우스 클릭시
        {
            GameObject selectedObj = null;
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //레이캐스트로 오브제트 판단
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);
            if (hit.collider != null)
            {
                selectedObj = hit.collider.gameObject;
                if (selectedObj.tag == "Dragon")
                {
                    for (int i = 0; i < dragonArr.Length; i++)
                    {
                        if (selectedObj.GetComponent<Dragon>().DragonName == dragonArr[i].name)
                        {
                            if (i == 0) MainSingleton.dragon = 1;
                            if (i == 1) MainSingleton.dragon = 2;
                            if (i == 2) MainSingleton.dragon = 3;
                            if (i == 3) MainSingleton.dragon = 4;
                            if (i == 4) MainSingleton.dragon = 5;
                            Debug.Log(MainSingleton.dragon);
                        }
                    }
                    Choice.ChoiceD();
                }
            }
        }
    }
}
