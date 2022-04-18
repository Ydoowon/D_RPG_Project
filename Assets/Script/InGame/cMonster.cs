using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class cMonster : cCharacteristic, BattleSystem
{
    public enum STATE
    {
        CREAT, ROAMING, BATTLE, DEAD        
    }

    public STATE myState = STATE.CREAT;

    public Stats myStats;

    Coroutine moveRoutine = null;
    Coroutine rotRoutine = null;

    Vector3 roamingArea = Vector3.zero; // 로밍할 구역
    Vector3 startPos = Vector3.zero; // 몬스터가 등장한 위치
    Vector3 dir = Vector3.zero; // 몬스터가 이동할 방향
    float dist = 0.0f; // 몬스터가 이동할 거리

    public float MoveSpeed = 3.0f; // 몬스터 이동 속도
    public float RotSpeed = 360.0f; // 몬스터 회전 속도
    public float RoamingWaitTime = 3.0f; // 몬스터 로밍간 대기시간

    public float ATK_Range; // 공격범위
    public float ATK_WaitingTime; // 공격 대기시간

    public void OnDamage(float damage)
    {

    }

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
                MonsterMove();
                break;
            case STATE.BATTLE:
                DetectMove();
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

    public void OnBattle()
    {
        StopAllCoroutines();
        ChangeState(STATE.BATTLE);
    }

    void DetectMove()
    {
        // 따라갈 타겟설정
        Vector3 myTarget = myDetection.Target.transform.position;

        dir = myTarget - this.transform.position; // 이동 방향
        dist = dir.magnitude; // 목표지점까지의 거리
        dir.Normalize();

        // 회전
        if (rotRoutine != null)
        {
            StopCoroutine(rotRoutine);
        }
        rotRoutine = StartCoroutine(Rotate());

        // 이동 - 대상을 따라다니도록
        if (moveRoutine != null)
        {
            StopCoroutine(moveRoutine);
        }
        moveRoutine = StartCoroutine(Attacking());
    }

    IEnumerator Attacking()
    {
        float AttackTime = ATK_WaitingTime; // 첫 공격시 딜레이 없이 바로 공격

        while (true)
        {
            if (dist > ATK_Range) // 공격범위 밖에 있을 경우 따라감
            {
                myAnim.SetBool("IsWalk", true); // idle -> walk_front 

                float delta = MoveSpeed * Time.deltaTime; // 이동 거리

                delta = delta > dist ? dist : delta; // 이동 거리가 남은 거리보다 클 경우 남은 거리 만큼만 이동

                this.transform.Translate(dir * delta);
                dist -= delta;
            }
            else // 공격범위 내에 있을 경우 공격
            {
                myAnim.SetBool("IsWalk", false); // walk_front -> idle

                if (myAnim.GetBool("IsAttack") == false)
                {                    
                    AttackTime += Time.deltaTime;

                    if(AttackTime >= ATK_WaitingTime)
                    {
                        // 공격
                        myAnim.SetTrigger("Attack");
                        AttackTime = 0.0f;
                    }
                }
            }
            yield return null;
        }
    }

    void MonsterMove()
    {
        // 이동방향 설정
        DirectionSetting(); 

        // 회전
        if (rotRoutine != null)
        {
            StopCoroutine(rotRoutine);
        }
        rotRoutine = StartCoroutine(Rotate());

        // 이동
        if (moveRoutine != null)
        {
            StopCoroutine(moveRoutine);
        }
        moveRoutine = StartCoroutine(Roaming());

    }   

    void DirectionSetting()
    {
        // 이동할 지점을 랜덤으로 설정
        roamingArea.x = startPos.x + Random.Range(-5.0f, 5.0f);
        roamingArea.z = startPos.z + Random.Range(-5.0f, 5.0f);

        dir = roamingArea - this.transform.position; // 이동 방향
        dist = dir.magnitude; // 목표지점까지의 거리
        dir.Normalize();
    }

    IEnumerator RoamingWait(float t, UnityAction done)
    {
        myAnim.SetBool("IsWalk", false); // walk_front -> idle
        yield return new WaitForSeconds(t); // t초만큼 기다림
        done?.Invoke(); // delegate에 저장된 함수 실행
    }

    IEnumerator Roaming()
    {
        myAnim.SetBool("IsWalk", true); // idle -> walk_front                

        while (!Mathf.Approximately(dist, 0.0f))
        {
            float delta = MoveSpeed * Time.deltaTime; // 이동 거리

            delta = delta > dist ? dist : delta; // 이동 거리가 남은 거리보다 클 경우 남은 거리 만큼만 이동

            this.transform.Translate(dir * delta);
            dist -= delta;

            yield return null;
        }

        StartCoroutine(RoamingWait(RoamingWaitTime, () => MonsterMove())); // 다시 다른곳으로 로밍시작
        
    }

    IEnumerator Rotate()
    {
        float rad = Mathf.Acos(Vector3.Dot(myAnim.transform.forward, dir)); // 이동할 지점까지의 각도를 구함
        float angle = 180 * (rad / Mathf.PI); // degree 각도로 바꿈
        float rotDir = 1.0f; // 회전 방향값 => 오른쪽

        if (Vector3.Dot(myAnim.transform.right, dir) < 0.0f)
        {
            rotDir = -1.0f; // 왼쪽방향
        }

        while (!Mathf.Approximately(angle, 0.0f))
        {
            float delta = RotSpeed * Time.deltaTime;

            delta = delta > angle ? angle : delta;

            myAnim.transform.Rotate(Vector3.up * delta * rotDir);
            angle -= delta;

            yield return null;
        }
    }

    
}
