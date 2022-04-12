using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class cPlayerMove : cCharacter
{
    public FloatingJoystick joystick;
    Vector3 moveVec;

    Vector2 joystickPos;
    public float MoveSpeed = 5.0f;

    // Update is called once per frame
    void Update()
    {
        // 조이스틱 입력값
        float x = joystick.Horizontal;
        float z = joystick.Vertical;

        // 이동
        moveVec = new Vector3(x, 0, z) * MoveSpeed * Time.deltaTime;
        myRigid.MovePosition(myRigid.position + moveVec);

        // 입력이 없을경우 회전x
        if (moveVec.sqrMagnitude == 0) return; // sqrMganitude : 벡터의 제곱크기 반환

        // 회전
        if (moveVec != Vector3.zero)
        {
            Quaternion dirQuat = Quaternion.LookRotation(moveVec); // 회전해야하는 값을 저장
            Quaternion moveQuat = Quaternion.Slerp(myRigid.rotation, dirQuat, 0.6f); // 현재 회전값과 바뀔 회전값을 보간
            myRigid.MoveRotation(moveQuat);
        }

    }

    private void LateUpdate()
    {
        // 애니메이션 - 블랜드트리
        myAnim.SetFloat("x", joystick.Horizontal);
        myAnim.SetFloat("y", joystick.Vertical);
    }
}
