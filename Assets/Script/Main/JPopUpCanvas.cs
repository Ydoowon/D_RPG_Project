using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JPopUpCanvas : MonoBehaviour
{
    [SerializeField]
    private GameObject UI_Canvas; // 껏다 킬 UI캔버스(시스템 미구현 팝업창)

    [SerializeField]
    private AudioClip Ui_Click; // UI클릭했을때 재생할 효과음

    [SerializeField]
    private AudioClip DunGeon_Click; // 던전 선택 클릭했을때 재생할 효과음

    AudioSource audioSource; // 효과음 재생할 오디오클립

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public void EnterPopUp() // 미구현 아이콘들 누를때 함수
    {
        audioSource.PlayOneShot(Ui_Click);
        UI_Canvas.SetActive(true);
    }

    public void ExitPopUp() // 미구현 팝업 확인창 누를때 함수
    {
        audioSource.PlayOneShot(Ui_Click);
        UI_Canvas.SetActive(false);
    }

    public void EnterDunGeon() // 던전선택 아이콘 눌렀을때 함수
    {
        audioSource.PlayOneShot(DunGeon_Click);
        StartCoroutine(Delay(1)); // 효과음 재생을 위한 1초 딜레이 코루틴 (안하면 효과음 소리가 안나고 씬이동함)
    }

    IEnumerator Delay(float t)
    {
        yield return new WaitForSeconds(t);
        SceneManager.LoadScene("SelecteDungeon");
    }

    
}
