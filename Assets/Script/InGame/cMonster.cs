using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cMonster : cCharacteristic
{
    public enum STATE
    {
        NONE, CREAT, ROAMING, BATTLE, DEAD        
    }

    public STATE myState = STATE.NONE;

    void Start()
    {
        ChangeState(STATE.CREAT);
    }

    void Update()
    {
        StateProcess();
    }

    void ChangeState(STATE s)
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

    void StateProcess()
    {
        // 매 프레임마다 해야할 일들을 동작시켜줌 -> update문에서 매 프레임마다 호출시킴
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
}
