using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LogicGOScript : MonoBehaviour
{
    public static LogicGOScript Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    LogicScript ls;
    XpManager xpM;
    [SerializeField] private TextMeshProUGUI scoreUI;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private TextMeshProUGUI gameOverText;

    void Start()
    {
        ls = LogicScript.Instance;

        if (ls == null)
        {
            Debug.LogError("LogicScript instance is null. Cannot update score.");
        }

        xpM = XpManager.Instance;

        gameOver();
        scoreUI.text = ls.addScore();

        Debug.Log(ls.addScore());
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
            xpM.AddXp(ls.GetXpAmountPerGame());
        }
        else
        {
            Debug.LogError("XpManager instance is null. Cannot update XP gained.");
        }
    }

    public void RestartGame()
    {
        if (ls != null)
        {
            ls.RestartGame();
            LoadScene("GameplayScene");
        }
        else
        {
            Debug.LogError("LogicScript instance is null. Cannot restart game.");
        }
    }

    public void gameOver()
    {
        ls.inGameOverState = true;
        gameOverText.text = $"{PlayerPrefs.GetString("user_name", "Player 1")} Died :(";
        UpdateHighScoreText();
        UpdateXpGained();
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
