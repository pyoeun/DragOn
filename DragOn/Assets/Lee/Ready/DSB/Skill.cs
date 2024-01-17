using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public string SkillName = null;
    [TextArea]
    public string SkillText = null;
    public string SkillCool = null;
    public float CoolTime = 0.0f;
}
