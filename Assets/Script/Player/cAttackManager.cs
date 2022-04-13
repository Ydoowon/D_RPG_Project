using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cAttackManager : cCharacter
{
    float Combo = 0;

    public void BasicAttack()
    {
        if (!myAnim.GetBool("IsAttack"))
        {
            myAnim.SetFloat("Combo", (int)(Combo++ % 4));
            myAnim.SetTrigger("Attack");
        }
    }

    public void Skill_1()
    {
        myAnim.SetTrigger("Skill");
    }
}
