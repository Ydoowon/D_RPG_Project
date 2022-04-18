using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JMain : MonoBehaviour 
{

    public GameObject Click;
    public GameObject ClickTarget;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


       
            if (Input.GetMouseButtonUp(0))
            {
                Click.transform.position = Input.mousePosition;
                Click.SetActive(true);
               StartCoroutine(Click_Delay(0.5f));
                
            }
      
    }

    IEnumerator Click_Delay(float t)
    {
        yield return new WaitForSeconds(t);
        Click.SetActive(false); 


    }


}
