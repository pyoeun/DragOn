using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSet : MonoBehaviour
{
    float time = 0.0f;
    [SerializeField] Image Skill;
    [SerializeField] Image Skillbackground;

    [SerializeField] GameObject[] Skills;
    Skill s;
    private void Start()
    {
        time = 100.0f;
        Skill.sprite = Skills[MainSingleton.skill - 1].GetComponent<SpriteRenderer>().sprite;
        Skillbackground.sprite = Skills[MainSingleton.skill - 1].GetComponent<SpriteRenderer>().sprite;
        s = Skills[MainSingleton.skill - 1].GetComponent<Skill>();
    }
    private void Update()
    {
        time += Time.deltaTime;

        if (time > s.CoolTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(MainSingleton.skill == 1)
                {

                }
                if (MainSingleton.skill == 2)
                {

                }
                if (MainSingleton.skill == 3)
                {

                }
            }
        }
        Skill.fillAmount = s.CoolTime / time;
    }
}
