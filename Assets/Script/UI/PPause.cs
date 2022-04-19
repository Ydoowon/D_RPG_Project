using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PPause : MonoBehaviour
{

    public bool IsPause;
    public GameObject Pausepanel;
    // Start is called before the first frame update
    void Start()
    {
        IsPause = false;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangePauseT()
    {
        if (IsPause == false)
        {
            Time.timeScale = 0;
            IsPause = true;
            Pausepanel.SetActive(true);
            return;
            
        }
      
    }
    public void ChangePauseF()
    {
        if (IsPause == true)
        {
            Time.timeScale = 1;
            IsPause = false;
            Pausepanel.SetActive(false);
            return;
        }
    }
    public void ClickExit()
    {
        SceneManager.LoadScene(0);
    }
}
