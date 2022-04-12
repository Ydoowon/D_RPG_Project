using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JPlayerMove : MonoBehaviour
{
    Vector3 Rot;
    public float MoveSpeed = 3.0f;

    // Start is called before the first frame update
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
            Rot.y += X;
        }
        this.transform.Rotate(Vector3.right*Time.deltaTime*MoveSpeed);

    }
}
