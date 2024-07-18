using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class start_ui_button : MonoBehaviour
{

    void Start()
    {
        Button nextStageButton = GetComponent<Button>();
        if (nextStageButton != null)
        {
            nextStageButton.onClick.AddListener(LoadNextStage);
        }
        else
        {
            Debug.LogError("Button component not found on the object.");
        }
    }

    void LoadNextStage()
    {
        // 다음 스테이지로 씬을 로드합니다.
        SceneManager.LoadScene("level1", LoadSceneMode.Single);
    }
}


