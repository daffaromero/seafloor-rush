using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class LogicScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI predatorsKilled;
    List<Predator> predators = new List<Predator>();

    #region Singleton

    public static LogicScript Instance;

    private void Awake()
    {
        if(PlayerPrefs.GetInt("HighScore") == 0)
        {
            ActivateTutorial();
        }
        if (Instance == null) Instance = this;
        predators = GameObject.FindObjectsOfType<Predator>().ToList();
        UpdatePredatorKillCount();
    }
    #endregion

    public float playerScore = 0f;
    public float currentRoundScore = 0f;

    public int scoreRound;
    private int predatorKillCount = 0;

    UIManagerScript uim;
    public string scoreText;
    public bool inGameOverState = false;
    public GameObject tutorialScreen;
    public GameObject ContinueButton;

    [ContextMenu("Increase Score")]
    public string addScore()
    {
        if (!inGameOverState)
        {
            currentRoundScore += Time.deltaTime;
            playerScore = currentRoundScore;
            scoreRound = Mathf.RoundToInt(playerScore);
            //CheckHighScore();
        }

        return scoreRound.ToString();
    }

    public string CheckHighScore()
    {
        if (scoreRound > PlayerPrefs.GetInt("HighScore", 0) && inGameOverState)
        {
            PlayerPrefs.SetInt("HighScore", scoreRound);
            //uim.UpdateHighScoreText();
        }

        return PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    // Safeguarding against null reference exceptions
    private void OnEnable()
    {
        Predator.OnPredatorKilled += HandlePredatorKilled;
    }

    private void OnDisable()
    {
        Predator.OnPredatorKilled -= HandlePredatorKilled;
    }

    void HandlePredatorKilled(Predator pred)
    {
        if (predators.Contains(pred))
        {
            predatorKillCount++;
            predators.Remove(pred);
            UpdatePredatorKillCount();
        }
    }

    public void AddPredatorToList(Predator pred)
    {
        predators.Add(pred);
    }

    public void UpdatePredatorKillCount()
    {
        predatorsKilled.text = predatorKillCount.ToString();
    }

    public void ActivateTutorial()
    {
        tutorialScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void Continue()
    {
        tutorialScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        playerScore = 0;
        inGameOverState = false;
    }
}
