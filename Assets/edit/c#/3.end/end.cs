using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class end : MonoBehaviour
{
    public string sceneToLoad; // 이동할 씬의 이름

    void Start()
    {
        // 버튼에 이벤트 리스너 추가
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(LoadSceneOnClick);
        }
        else
        {
            Debug.LogError("Button component not found!");
        }
    }

    // 버튼을 클릭했을 때 실행될 메서드
    void LoadSceneOnClick()
    {
        SceneManager.LoadScene("start"); // 지정된 씬으로 이동
    }
}
