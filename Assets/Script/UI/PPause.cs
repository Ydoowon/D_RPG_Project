using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPause : MonoBehaviour
{

    public bool IsPause;
    // Start is called before the first frame update
    void Start()
    {
        IsPause = false;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        if (IsPause == false)
        {
            Time.timeScale = 0;
            IsPause = true;
            return;
        }
        if (IsPause == true)
        {
            Time.timeScale = 1;
            IsPause = false;
            return;
        }
    }
}
