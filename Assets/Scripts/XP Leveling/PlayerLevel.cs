using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevel : MonoBehaviour
{
    int totalXp, maxXp, currentLevel;
    XpManager xpManager;

    private void Start()
    {


    }
    private void OnEnable()
    {
        xpManager = XpManager.Instance;

        if (xpManager == null)
        {
            Debug.LogError("XpManager is null. Called from PlayerLevel.cs");
        }

        xpManager.OnXpChange += HandleXpChange;
        LoadPlayerData();
    }

    private void OnDisable()
    {
        xpManager.OnXpChange -= HandleXpChange;
        SavePlayerData();
    }

    private void HandleXpChange(int newXp)
    {
        totalXp += newXp;

        if (totalXp >= maxXp)
        {
            Debug.Log("Level up!");
            LevelUp();
        }
        SavePlayerData();
    }

    private void LevelUp()
    {
        currentLevel++;

        // XP carries over to next level
        totalXp -= maxXp;
        maxXp = CalculateMaxXp(currentLevel);
        SavePlayerData();
    }

    private void SavePlayerData()
    {
        PlayerPrefs.SetInt("totalXp", totalXp);
        PlayerPrefs.SetInt("maxXp", maxXp);
        PlayerPrefs.SetInt("currentLevel", currentLevel);
        PlayerPrefs.Save();
    }

    private void LoadPlayerData()
    {
        totalXp = PlayerPrefs.GetInt("totalXp", 0);
        maxXp = PlayerPrefs.GetInt("maxXp", CalculateMaxXp(currentLevel));
        currentLevel = PlayerPrefs.GetInt("currentLevel", 1);

        Debug.Log($"totalXp: {totalXp}, maxXp: {maxXp}, currentLevel: {currentLevel}");
    }

    private int CalculateMaxXp(int level)
    {
        return level * 100 + 75;
    }
}
