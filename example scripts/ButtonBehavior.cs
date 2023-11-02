using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviors : MonoBehaviour
{
    public GameObject MainCanvas;
    public GameObject SettingsCanvas;
    public GameObject LevelsCanvas;

    public void LoadSceneButton(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void SettingsOpen()
    {
        MainCanvas.SetActive(false);
        SettingsCanvas.SetActive(true);
    }

    public void SettingsClose()
    {
        MainCanvas.SetActive(true);
        SettingsCanvas.SetActive(false);
    }

    public void LevelsOpen()
    {
        MainCanvas.SetActive(false);
        LevelsCanvas.SetActive(true);
    }

    public void LevelsClose()
    {
        MainCanvas.SetActive(true);
        LevelsCanvas.SetActive(false);
    }
}
