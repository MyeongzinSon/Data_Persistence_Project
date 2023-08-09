using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    public TMP_Text bestRecordText;
    public TMP_InputField nameInput;

    string bestRecordInitialString;

    public void Start()
    {
        bestRecordText.text = DataManager.Instance.GetBestRecordString();

    }

    public void StartButtonClicked()
    {
        DataManager.Instance.playerName = nameInput.text;
        SceneManager.LoadScene(1);
    }

    public void QuitButtonClicked()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
