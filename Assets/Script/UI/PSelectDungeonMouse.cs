using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PSelectDungeonMouse : MonoBehaviour
{

    public LayerMask CrashMask;
    Vector3 dir = Vector3.zero;
    Vector3 DragStart = Vector3.zero;
    bool IsDrag = false;
    public float MoveSpeed=2.0f;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
    }
 
    public void MoveCamera()
    {
        if(Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray,out RaycastHit hit,9999.0f,CrashMask))
            {
                DragStart = hit.point;
                IsDrag = true;
            }
        }

        if(IsDrag==true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray,out RaycastHit hit,9999.0f,CrashMask))
            {

                dir = hit.point - DragStart;
                DragStart = hit.point;
                if(dir.magnitude>0)
                {
                    Camera.main.transform.Translate(-dir);
                }
                
            }
        }
        
    }
}
