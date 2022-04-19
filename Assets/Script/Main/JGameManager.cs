using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JGameManager : MonoBehaviour
{

    private static JGameManager instance; //스태틱은 1개 // 모든 싱글톤 개체들이 공유됨 // 외부에서 수정X 유일성확보

    public static JGameManager Instance 
    {
        get
        {
            if(instance == null) // 인스턴스가 비어있는지 검사
            {
                var obj = FindObjectOfType<JGameManager>(); //씬안에 jGameManager 컴포넌트를 가지고있는 오브젝트가 있는지 검사
                if(obj != null) //만약 jGameManager 컴포넌트를 가지고있는 오브젝트가 존재한다면
                {
                    instance = obj; // 인스턴스에 그 객체를 넣어줌 
                }
                else //인스턴스가 존재하지 않는다면
                {
                    var newObj = new GameObject().AddComponent<JGameManager>(); // 새 게임오브젝트 생성하고 jgamemanager를 붙여줌
                    instance = newObj; // 그 게임오브젝트를 인스턴스에 넣어줌
                }
            }
            return instance;
        }
    }

    private void Awake() //게임오브젝트가 생성되면 가장먼저 실행
    {
        var objs = FindObjectsOfType<JGameManager>();//씬에 같은 컴포넌트를 가진 오브젝트가 몇개가 있는지 검사
        if(objs.Length != 1) // 1개가 아니라면 = 다른 오브젝트가 있다는 의미 , 이 객체보다 먼저 생성된 객체일 확률이 높음
        {
            Destroy(gameObject); //방금 생성된 객체는 파괴
            return;
        }
        DontDestroyOnLoad(gameObject); //씬이 바뀌어도 게임오브젝트가 파괴되지 않도록함
    }

    public struct Player_Stat
    {
        string Nickname;
        int Money;
        int Crystal;

    }

    Player_Stat player_stat;

    void Start()
    {
        player_stat = new Player_Stat();
        
    }

    
    void Update()
    {
        
    }
}
