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
    void Start()
    {
        ls = LogicScript.Instance;
        gameOver();
    }

    private void OnGUI() {
        scoreUI.text = ls.addScore();
        UpdateHighScoreText();
    }
    public void UpdateHighScoreText()
    {
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
        Debug.Log("Mati");
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
