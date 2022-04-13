using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringArm : MonoBehaviour
{
    Vector3 Rot = Vector3.zero;
    public float RotSpeed = 3.0f;
    public Vector2 HorizontalRotRange;
    public Vector2 VerticalRotRange;
    public float SmoothRotSpeed = 5.0f;


    void Start()
    {
        Rot = this.transform.rotation.eulerAngles;

     
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
     

            float X = Input.GetAxis("Mouse X");
            float Y = Input.GetAxis("Mouse Y");
            Rot.y += X * RotSpeed;
            Rot.x += Y * RotSpeed;

            //if (Rot.y < 0) Rot.y += 180.0f;
            // else Rot.y -= 180.0f;
            //Rot.y = Mathf.Clamp(Rot.y, HorizontalRotRange.x, HorizontalRotRange.y);
            Rot.x = Mathf.Clamp(Rot.x, VerticalRotRange.x, VerticalRotRange.y);

            
            this.transform.rotation = Quaternion.Euler(Rot);
        }

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.Euler(Rot), Time.deltaTime * SmoothRotSpeed);


    }
}