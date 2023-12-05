using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LogicGOScript : MonoBehaviour
{
    LogicScript ls;
    [SerializeField] private TextMeshProUGUI scoreUI;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private TextMeshProUGUI gameOverText;
    void Start()
    {
        ls = LogicScript.Instance;
        gameOver();
        scoreUI.text = ls.addScore();

        if (ls.inGameOverState)
        {
            UpdateHighScoreText();
        }
    }

    public void UpdateHighScoreText()
    {
        ls.CheckHighScore();
        highScoreText.text = $"High Score: {PlayerPrefs.GetInt("HighScore", 0)}";
    }

    public void restartGame()
    {
        ls.playerScore = 0;
        ls.inGameOverState = false;
    }

    public void gameOver()
    {
        ls.inGameOverState = true;
        gameOverText.text = $"{PlayerPrefs.GetString("user_name", "Player 1")} Died :(";
        UpdateHighScoreText();

    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
