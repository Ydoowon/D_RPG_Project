using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillCoolTime : MonoBehaviour
{
    public Image skillFilter;
    public float coolTime; 

     void Start()
    {
        skillFilter.fillAmount = 1;
    }
    public void UseSkill()
    {
        Debug.Log("use Skill");
        skillFilter.fillAmount = 1;
        StartCoroutine("CoolTime");
    }
    IEnumerator CoolTime()
    {
        while(skillFilter.fillAmount >0 )
        {
            skillFilter.fillAmount -= 1 * Time.smoothDeltaTime / coolTime;
            yield return null;  
        }
        yield break;
    }
}
