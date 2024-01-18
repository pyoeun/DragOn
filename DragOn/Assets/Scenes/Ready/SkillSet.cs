using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSet : MonoBehaviour
{
    float time = 0.0f;
    [SerializeField] Image Skill;
    [SerializeField] Image Skillbackground;
    [SerializeField] GameObject Shuild;

    [SerializeField] GameObject[] Skills;
    Skill s;
    private void Start()
    {
        time = 100.0f;
        Skill.sprite = Skills[MainSingleton.skill - 1].GetComponent<SpriteRenderer>().sprite;
        Skillbackground.sprite = Skills[MainSingleton.skill - 1].GetComponent<SpriteRenderer>().sprite;
        s = Skills[MainSingleton.skill - 1].GetComponent<Skill>();
        if (MainSingleton.dragon == 4)
        {
            s.CoolTime = s.CoolTime * 0.7f;
        }
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
                    gameObject.GetComponent<GameSetting>().nowHelth += 1;
                    time = 0.0f;
                }
                if (MainSingleton.skill == 2)
                {
                    time = 0.0f;
                }
                if (MainSingleton.skill == 3)
                {
                    Destroy(Instantiate(Shuild, transform),3);
                    time = 0.0f;
                }
            }
        }
        Skill.fillAmount = time / s.CoolTime;
    }
}
