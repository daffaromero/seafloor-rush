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

    private void Awake() {
        if(Instance == null) Instance = this;
        predators = GameObject.FindObjectsOfType<Predator>().ToList();
        UpdatePredatorKillCount();
    }
    #endregion
    
    public float playerScore = 0f;
    public int scoreRound;
    private int predatorKillCount = 0;

    UIManagerScript uim;
    public string scoreText;
    public bool inGameOverState = false;

    [ContextMenu("Increase Score")]
    public string addScore()
    {
        if (!inGameOverState)
        {
            playerScore = playerScore + Time.deltaTime;
            scoreRound = Mathf.RoundToInt(playerScore);
            CheckHighScore();
        }

        scoreText = scoreRound.ToString();

        return scoreText;
    }

    public void CheckHighScore() 
    {
        if(scoreRound > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", scoreRound);
            uim.UpdateHighScoreText();
        }
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
}
