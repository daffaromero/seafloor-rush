using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MainMenu : MonoBehaviour
{
    public GameObject tutorialScreen;

    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ActivateTutorial()
    {
        tutorialScreen.SetActive(true);
    }

    public void CloseTutorial()
    {
        tutorialScreen.SetActive(false);
    }
}
