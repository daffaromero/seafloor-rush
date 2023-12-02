using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    #region Singleton

    public static LogicScript Instance;

    private void Awake() {
        if(Instance == null) Instance = this;
    }
    #endregion
    public float playerScore = 0f;
    public string scoreText;
    public GameObject gameOverScreen;

    private bool inGameOverState = false;

    [ContextMenu("Increase Score")]
    public string addScore()
    {
        if (!inGameOverState)
        {
            playerScore = playerScore + Time.deltaTime;
        }

        return scoreText = Mathf.RoundToInt(playerScore).ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        playerScore = 0;
        inGameOverState = false;
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        inGameOverState = true;
    }
}
