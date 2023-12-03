using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LogicGOScript : MonoBehaviour
{
    LogicScript ls;
    UIManagerScript uim;
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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void restartGame()
    {
        SceneManager.LoadScene("GameplayScene");
        ls.playerScore = 0;
        ls.inGameOverState = false;
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        ls.inGameOverState = true;
    }
}
