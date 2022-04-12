using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cSpringArm : MonoBehaviour
{
    public FloatingJoystick joystick;
    public Transform myCam;

    Vector3 TargetRot;

    public float SmoothRotSpeed = 5.0f;
    public float HorizontalRotSpeed = 2.0f; // 수평 이동속도

    public Vector2 VerticalRotRange; // 상하 회전 범위 
    public LayerMask CrashMask; // 카메라 바닥 충돌 layerMask
    public float VerticalRotSpeed = 2.0f; // 수직 이동속도
    public float CollsionOffset = 0.5f; // 카메라가 바닥에 떠있는 높이

    float ZoomDist = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        TargetRot = this.transform.rotation.eulerAngles; // 초기 회전위치 저장   
        ZoomDist = -myCam.localPosition.z; // 초기 카메라와 플레이어의 거리 저장
    }

    // Update is called once per frame
    void Update()
    {
        TargetRot.y += joystick.Horizontal * HorizontalRotSpeed; // 좌우회전
        TargetRot.x -= joystick.Vertical * VerticalRotSpeed; // 상하회전
        
        // 상하 범위 설정
        if (TargetRot.x > 180.0f)
        {
            TargetRot.x -= 360.0f;
        }
        TargetRot.x = Mathf.Clamp(TargetRot.x, VerticalRotRange.x, VerticalRotRange.y);

        // SpringArm이 직접 회전
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, 
            Quaternion.Euler(TargetRot), Time.deltaTime * SmoothRotSpeed);

        // 카메라를 공중에 띄움
        Ray ray = new Ray(this.transform.position, -this.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, CollsionOffset, CrashMask))
        {
            ZoomDist = Vector3.Distance(hit.point - ray.direction * CollsionOffset, this.transform.position); // 충돌이 난 지점까지 카메라를 옮겨줌
        }

        myCam.localPosition = -Vector3.forward * ZoomDist; // 카메라를 앞으로 줌 시킴
    }
}
