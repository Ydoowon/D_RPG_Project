using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class cMonster : cCharacteristic
{
    public enum STATE
    {
        CREAT, ROAMING, BATTLE, DEAD        
    }

    public STATE myState = STATE.CREAT;

    Vector3 startPos = Vector3.zero; // 몬스터가 등장한 위치

    public float MoveSpeed = 3.0f; // 몬스터 이동 속도
    public float RoamingWaitTime = 3.0f; // 몬스터 로밍간 대기시간

    void Start()
    {
        ChangeState(STATE.ROAMING); // 로밍상태로 변경
    }

    void Update()
    {
        StateProcess();
    }

    void ChangeState(STATE s)
    {
        if (myState == s) return;
        myState = s;

        switch (myState)
        {
            case STATE.CREAT:
                startPos = this.transform.position; // 초기 위치 저장
                break;
            case STATE.ROAMING:
                StartCoroutine(RoamingWait(RoamingWaitTime, () =>  StartCoroutine(Roaming()))); // 로밍, 람다식 이용
                break;
            case STATE.BATTLE:
                break;
            case STATE.DEAD:
                break;
        }
    }

    void StateProcess()
    {
        switch (myState)
        {
            case STATE.CREAT:
                break;
            case STATE.ROAMING:
                break;
            case STATE.BATTLE:
                break;
            case STATE.DEAD:
                break;
        }
    }

    IEnumerator RoamingWait(float t, UnityAction done)
    {
        yield return new WaitForSeconds(t); // t초만큼 기다림
        done?.Invoke(); // delegate에 저장된 함수 실행
    }

    IEnumerator Roaming()
    {
        // 이동할 지점을 랜덩으로 설정
        Vector3 roamingArea = new Vector3();
        roamingArea.x = startPos.x + Random.Range(-5.0f, 5.0f);
        roamingArea.z = startPos.z + Random.Range(-5.0f, 5.0f);

        Vector3 dir = roamingArea - this.transform.position; // 이동 방향
        float dist = dir.magnitude; // 목표지점까지의 거리
        dir.Normalize();             

        while (!Mathf.Approximately(dist, 0.0f))
        {
            float delta = MoveSpeed * Time.deltaTime; // 이동 거리

            delta = delta > dist ? dist : delta; // 이동 거리가 남은 거리보다 클 경우 남은 거리 만큼만 이동

            this.transform.Translate(dir * delta);
            dist -= delta;

            yield return null;
        }

        StartCoroutine(RoamingWait(RoamingWaitTime, () => StartCoroutine(Roaming()))); // 다시 다른곳으로 로밍시작
    }
}
