using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class LogicScript : MonoBehaviour
{
    public GameObject PausePanel;
    [SerializeField] TextMeshProUGUI predatorsKilled;
    [SerializeField] TextMeshProUGUI highScoreText;
    List<Predator> predators = new List<Predator>();

    #region Singleton
    private static LogicScript instance;

    public static LogicScript Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("LogicScript instance is null. Cannot update score.");
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(instance.gameObject);
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        if (PlayerPrefs.GetInt("HighScore") == 0)
        {
            ActivateTutorial();
        }
        predators = GameObject.FindObjectsOfType<Predator>().ToList();
        UpdatePredatorKillCount();
    }
    #endregion

    public float playerScore = 0f;
    public float currentRoundScore = 0f;
    public int scoreRound;

    private int predatorKillCount = 0;
    public bool inGameOverState = false;
    public GameObject tutorialScreen;
    public GameObject ContinueButton;


    public int GetXpAmountPerGame()
    {
        Debug.Log("XpGain: " + PlayerPrefs.GetInt("XpGain", 0));
        return PlayerPrefs.GetInt("XpGain", 0);
    }

    public string addScore()
    {
        if (!inGameOverState)
        {
            currentRoundScore += Time.deltaTime;
            playerScore = currentRoundScore;
            scoreRound = (predatorKillCount * 10) + Mathf.RoundToInt(playerScore);
            CheckHighScore();
        }

        return scoreRound.ToString();
    }

    public string CheckHighScore()
    {
        // xpAmount = scoreRound;
        PlayerPrefs.SetInt("XpGain", scoreRound);

        if (scoreRound > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", scoreRound);
            highScoreText.text = $"High Score: {PlayerPrefs.GetInt("HighScore", 0)}";
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
        if (predatorsKilled != null)
        {
            predatorsKilled.text = predatorKillCount.ToString();
        }
        else
        {
            Debug.LogError("predatorsKilled is null in UpdatePredatorKillCount.");
        }
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

    public void PauseGame()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        ResetGame();
        SceneManager.LoadScene("GameplayScene");

    }

    public void ResetGame()
    {
        Time.timeScale = 1;
        currentRoundScore = 0f;
        playerScore = 0f;
        predatorKillCount = 0;
        inGameOverState = false;
    }
}
