using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LogicGOScript : MonoBehaviour
{
    LogicScript ls;
    XpManager xpM;
    [SerializeField] private TextMeshProUGUI scoreUI;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private TextMeshProUGUI gameOverText;

    void Start()
    {
        ls = LogicScript.Instance;
        xpM = XpManager.Instance;

        if (ls == null)
        {
            Debug.LogError("LogicScript instance is not properly initialized.");
        }
        if (xpM == null)
        {
            Debug.LogError("XpManager instance is not properly initialized.");
        }

        gameOver();
        scoreUI.text = ls.addScore();

    }

    public void UpdateHighScoreText()
    {
        ls.CheckHighScore();
        highScoreText.text = $"High Score: {PlayerPrefs.GetInt("HighScore", 0)}";
    }

    public void UpdateXpGained()
    {
        if (xpM != null)
        {
            xpM.AddXp(ls.GetXpAmount());
        }
        else
        {
            Debug.LogError("XpManager instance is null. Cannot update XP gained.");
        }
    }

    public void restartGame()
    {
        Time.timeScale = 1;
        ls.playerScore = 0;
        ls.inGameOverState = false;
        LoadScene("GameplayScene");
    }

    public void gameOver()
    {
        ls.inGameOverState = true;
        gameOverText.text = $"{PlayerPrefs.GetString("user_name", "Player 1")} Died :(";
        UpdateHighScoreText();
        UpdateXpGained();
        // xpM.AddXp(ls.GetXpAmount());
        // Debug.Log("XP added: " + ls.GetXpAmount());

    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
