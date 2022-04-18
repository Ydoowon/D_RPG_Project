using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Stats
{
    public float HP; // 체력

    public float ATK; // 공격력 
    public float DEF; // 방어력 
}

public interface BattleSystem
{
    void OnDamage(float damage);    
}


public class cCharacteristic : MonoBehaviour
{
    Animator _anim = null;
    protected Animator myAnim
    {
        get // 사용할 때 바로 적용되도록 property 사용
        {
            if (_anim == null) _anim = this.GetComponent<Animator>(); // _anim을 호출하면 항상 값을 가지고 있다는 확신이 생김 

            if (_anim == null) _anim = this.GetComponentInChildren<Animator>(); // 자식에 있을때도 호출

            return _anim;
        }
    }

    Rigidbody _rigid = null;
    protected Rigidbody myRigid
    {
        get // 사용할 때 바로 적용되도록 property 사용
        {
            if (_rigid == null) _rigid = this.GetComponent<Rigidbody>(); // _anim을 호출하면 항상 값을 가지고 있다는 확신이 생김 

            if (_rigid == null) _rigid = this.GetComponentInChildren<Rigidbody>(); // 자식에 있을때도 호출

            return _rigid;
        }
    }

    cAutoDetection _Detection = null;
    protected cAutoDetection myDetection
    {
        get // 사용할 때 바로 적용되도록 property 사용
        {
            if (_Detection == null) _Detection = this.GetComponent<cAutoDetection>(); // _anim을 호출하면 항상 값을 가지고 있다는 확신이 생김 

            if (_Detection == null) _Detection = this.GetComponentInChildren<cAutoDetection>(); // 자식에 있을때도 호출

            return _Detection;
        }
    }
}


