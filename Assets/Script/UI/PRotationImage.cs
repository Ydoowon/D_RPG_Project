using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PRotationImage : MonoBehaviour
{
    float rotSpeed = 200.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotSpeed * Time.deltaTime));
    }
}
