using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;


public class PlayerLevelBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    int totalXp, maxXp, currentLevel;

    void Start()
    {
        LoadPlayerData();
        UpdateXpBar(totalXp, maxXp);
    }

    public void LoadPlayerData()
    {
        totalXp = PlayerPrefs.GetInt("totalXp", 0);
        maxXp = PlayerPrefs.GetInt("maxXp", CalculateMaxXp(currentLevel));
        currentLevel = PlayerPrefs.GetInt("currentLevel", 1);
    }

    private int CalculateMaxXp(int level)
    {
        return level * 100 + 75;
    }

    public void UpdateXpBar(int currentValue, int maxValue)
    {
        slider.value = (float)currentValue / (float)maxValue;
        // Debug.Log(slider.value);
    }
}
