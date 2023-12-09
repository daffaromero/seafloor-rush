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
                instance = FindObjectOfType<LogicScript>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = "LogicScript";
                    instance = obj.AddComponent<LogicScript>();
                }
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
        else
        {
            Destroy(gameObject);
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

    private int xpAmount;

    public int GetXpAmount()
    {
        return xpAmount;
    }
    public string addScore()
    {
        if (!inGameOverState)
        {
            currentRoundScore += Time.deltaTime;
            playerScore = currentRoundScore;
            scoreRound = (predatorKillCount * 10) + Mathf.RoundToInt(playerScore);

            CheckHighScore();
            xpAmount = scoreRound;
        }

        return scoreRound.ToString();
    }

    public string CheckHighScore()
    {
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
