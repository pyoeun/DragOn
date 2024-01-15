using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class Choice_Skill : MonoBehaviour
{
    [SerializeField]
    GameObject cir;
    [SerializeField]
    GameObject[] SkillArr;
    [SerializeField]
    Transform spawnTrans;
    [SerializeField]
    float distance;
    GameObject k;
    private void Start()
    {
        cir.SetActive(false);
        float temp = -distance + 50;

        for (int i = 0; i < SkillArr.Length; i++)
        {
            GameObject t = Instantiate(SkillArr[i], spawnTrans);
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
                if (selectedObj.tag == "Skill")
                {
                    for (int i = 0; i < SkillArr.Length; i++)
                    {
                        if (selectedObj.GetComponent<Skill>().SkillName == SkillArr[i].name)
                        {
                            cir.SetActive(true);
                            if (i == 0) MainSingleton.skill = 1;
                            if (i == 1) MainSingleton.skill = 2;
                            if (i == 2) MainSingleton.skill = 3;
                            Debug.Log(MainSingleton.skill);
                            Destroy(k);
                            k = Instantiate(SkillArr[i], this.transform);
                        }
                    }
                    Choice.ChoiceS();
                }
            }
        }
    }
}
