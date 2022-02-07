using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.SceneManagement;
using TMPro;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] TMP_InputField nameInput;
    // Start is called before the first frame update
    void Start()
    {
        int highScore = PlayerDataManager.Instance.highScore;
        string highScoreName = PlayerDataManager.Instance.playerName;

        if (highScoreName != null)
        {
            highScoreText.text = "High Score: " + highScoreName + " : " + highScore;
        } else
        {
            highScoreText.text = "High Score: *Your Name Here* : 0";
        }
    }

    public void StartNew()
    {
        PlayerDataManager.Instance.playerName = nameInput.text;
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
