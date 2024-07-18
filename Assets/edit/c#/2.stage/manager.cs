using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class manager : MonoBehaviour
{
    // 맵에 존재하는 아이템 총 갯수
    public int TotalItemCount;

    // 현재 스테이지를 구분하는 것을 manager 가 
    // 하도록 한다.
    public int stage;
    public Text stageCountText;
    public Text playerCountText;

    // 떨여졌을때 효과음
    public AudioSource[] audio;

    void Awake()
    {
        stageCountText.text = "  /  " + TotalItemCount;
    }


    void Update()
    {
        // 'r' 키를 눌렀을 때 SceneManager.LoadScene(stage); 호출
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(stage);
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit(); // 현재 실행 중인 어플리케이션 종료
            // 이 기능은 에디터에서는 작동하지 않고 빌드된 어플리케이션에서 작동합니다.
        }
    }

    public void GetItem(int count)
    {
        playerCountText.text = count.ToString();        
    }




    // 바닥으로 떨어졌을때
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(stage);
            
        }
    }


}
