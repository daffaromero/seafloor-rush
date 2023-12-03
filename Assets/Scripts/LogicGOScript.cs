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
    public GameObject gameOverScreen;
    // Start is called before the first frame update
    void Start()
    {
        gameOver();
        scoreUI.text = ls.scoreText;
        highScoreText.text = $"High Score: {PlayerPrefs.GetInt("HighScore", 0)}";
    }

    public void restartGame()
    {
        ls.playerScore = 0;
        ls.inGameOverState = false;
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        ls.inGameOverState = true;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
