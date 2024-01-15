using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Choice_Dragon : MonoBehaviour
{
    [SerializeField] Text name;
    [SerializeField] Text attak;
    [SerializeField] Text health;
    [SerializeField] Text moveSpeed;
    [SerializeField] Text bulletSpeed;
    [SerializeField] Text attakDelay;

    [SerializeField] GameObject[] dragonArr = new GameObject[5];
    [SerializeField] Transform spawnTrans;
    [SerializeField] GameObject cir;
    [SerializeField] float distance;

    GameObject Next;
    GameObject k;

    private void Start()
    {
        name.color = Color.black;
        name.text = "?";
        cir.SetActive(false);
        float temp = -distance * 2;
        Next = GameObject.Find("SelectEnd");
        Next.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 0.6f);
        
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
                        if (selectedObj.GetComponent<Dragon>().DragonName == dragonArr[i].name)
                        {
                            cir.SetActive(true);
                            if (i == 0) MainSingleton.dragon = 1;
                            if (i == 1) MainSingleton.dragon = 2;
                            if (i == 2) MainSingleton.dragon = 3;
                            if (i == 3) MainSingleton.dragon = 4;
                            if (i == 4) MainSingleton.dragon = 5;
                            Debug.Log(MainSingleton.dragon);
                            Destroy(k);
                            k = Instantiate(dragonArr[i], this.transform);
                        }
                    }
                    Next.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
                }
                if (selectedObj.name == "SelectEnd")
                {
                    SceneManager.LoadScene("Ready_Skill");
                }
            }
        }
    }
}
