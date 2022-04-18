using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PSkillCoolTime : MonoBehaviour
{
    public Image skillbg;// fillaumout 조정용 이미지 
    public Image skillicon; // fillaumout 조정용 이미지 
    public float coolTime; // 쿨타임
    public TextMeshProUGUI coolTimeCounter; //남은 쿹타임 표시할 텍스트 
    private bool canUseSkill = true; // skill을 사용하지못하게 막는 bool값 
    private float currentCoolTime; //남은 쿨타임 추적변수 
     void Start()
    {
        skillbg.fillAmount = 1;
        skillicon.fillAmount = 1;
        GetComponent<Button>().interactable = true;
    }
    public void UseSkill()
    {
        if (canUseSkill)
        {
            skillbg.fillAmount = 0;
            skillicon.fillAmount = 0;
            StartCoroutine("CoolTime");

            currentCoolTime = coolTime;
            coolTimeCounter.text = "" + currentCoolTime;
            StartCoroutine("CoolTimeCounter");
            coolTimeCounter.alpha = 1.0f;
            canUseSkill = false;
            GetComponent<Button>().interactable = false;
        }

    }
    IEnumerator CoolTime()
    {
        while(skillbg.fillAmount <1 )
        {
            
            skillbg.fillAmount += 1 * Time.smoothDeltaTime / coolTime;
           skillicon.fillAmount += 1* Time.smoothDeltaTime / coolTime; 
            yield return null;  
        }
        canUseSkill = true;
        GetComponent<Button>().interactable = true;
        yield break;
    }

    IEnumerator CoolTimeCounter()
    {
        while(currentCoolTime >0)
        {
            yield return new WaitForSeconds(1.0f);
            currentCoolTime -= 1.0f;
            coolTimeCounter.text = "" + currentCoolTime;
        }
        coolTimeCounter.alpha = 0.0f;
        yield break;
    }
}
