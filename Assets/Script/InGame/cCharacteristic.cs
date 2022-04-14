using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
