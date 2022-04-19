using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cAutoDetection : MonoBehaviour
{
    public GameObject Target;
    public LayerMask DetectLayer;

    private void OnTriggerEnter(Collider other)
    {
        // 플레이어 감지
        if ((DetectLayer & (1 << other.gameObject.layer)) != 0)
        {
            Target = other.gameObject; // 리스트에 넣음
            this.transform.parent.GetComponent<cMonster>().OnBattle(); // 몬스터를 배틀상태로 변경
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Target = null; // 타겟 해제
    }
}


