using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManagerScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreUI;
    [SerializeField] private TextMeshProUGUI highScoreText;

    LogicScript ls;

    private void Awake()
    {
        UpdateHighScoreText();
    }
    private void Start()
    {
        ls = LogicScript.Instance;
    }

    private void OnGUI() {
        scoreUI.text = ls.addScore();

        if (ls.inGameOverState)
        {
            UpdateHighScoreText();
        }
    }
    public void UpdateHighScoreText()
    {
        highScoreText.text = $"High Score: {PlayerPrefs.GetInt("HighScore", 0)}";
    }
}
