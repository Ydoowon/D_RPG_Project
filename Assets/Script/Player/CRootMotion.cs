using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRootMotion : MonoBehaviour
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

    public Transform myRoot;
    public float MoveSpeed = 1.0f; // 플레이어 이동 속도

    private void OnAnimatorMove()
    {
        myRoot.GetComponent<Rigidbody>().MovePosition(myRoot.position + myAnim.deltaPosition * MoveSpeed); // 물리적인 이동을 하게 해줌
    }
}
