using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainManger : MonoBehaviour
{
    public GameObject Mainpanel;
    public GameObject TeamMangementpanel;
    public GameObject Optionpanel;
    public GameObject Followerpanel;
    public GameObject Inventorypanel;
    public GameObject Belongingspanel;
    public GameObject Costumepanel;
  

    public void OnclickTeamMangement() //팀관리 버튼 코드
    {
        Mainpanel.SetActive(false);
        TeamMangementpanel.SetActive(true);
    }
    public void BackMainteammange() //팀관리 왼쪽상단 뒤로가기 코드
    {
        TeamMangementpanel.SetActive(false);
        Mainpanel.SetActive(true);
    }
    public void OnclickOption()// 옵션 버튼 코드 
    {
        Optionpanel.SetActive(true);
    }
    public void CloseOption() //옵션 닫기버튼 코드
    {
        Optionpanel.SetActive(false);
    }
    public void GodengeonScene() //메인화면 배틀 신전환 코드
    {
        SceneManager.LoadScene(2);
    }
    public void OnclickInventory() //팀관리 버튼 코드
    {
        Mainpanel.SetActive(false);
        Inventorypanel.SetActive(true);
    }
    public void BackMainInventory() //장비 왼쪽상단 뒤로가기 코드
    {
        Inventorypanel.SetActive(false);
        Mainpanel.SetActive(true);
    }
    public void OnclickFollower() //팀관리 버튼 코드
    {
        Mainpanel.SetActive(false);
        Followerpanel.SetActive(true);
    }
    public void BackMainFollower() //부관 왼쪽상단 뒤로가기 코드
    {
        Followerpanel.SetActive(false);
        Mainpanel.SetActive(true);
    }
    public void OnclickBelongings() //팀관리 버튼 코드
    {
        Mainpanel.SetActive(false);
        Belongingspanel.SetActive(true);
    }
    public void BackMainBelongings() //소지품 왼쪽상단 뒤로가기 코드
    {
        Belongingspanel.SetActive(false);
        Mainpanel.SetActive(true);
    }
    public void OnclickCostume() //팀관리 버튼 코드
    {
        Mainpanel.SetActive(false);
        Costumepanel.SetActive(true);
    }
    public void BackMainCostume() //코스튬 왼쪽상단 뒤로가기 코드
    {
        Costumepanel.SetActive(false);
        Mainpanel.SetActive(true);
    }
}
