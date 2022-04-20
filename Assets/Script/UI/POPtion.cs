using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class POPtion : MonoBehaviour
{

    [Header("Option_select_image")]
    public Image[] option_image;
    // Start is called before the first frame update



    public void hilight_option(int index) //옵션 상단 메뉴들 눌렀을때
    {
        for (int i = 0; i < option_image.Length; i++)
        {
            option_image[i].enabled = (i == index);


        }

    }
}
