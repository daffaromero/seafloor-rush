using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerLevel : MonoBehaviour
{
    int totalXp, maxXp, currentLevel;
    XpManager xpManager;
    [SerializeField] private TextMeshProUGUI displayLevel;
    [SerializeField] private TextMeshProUGUI displayXP;
    private PlayerLevelBar playerLevelBar;
    private void Start()
    {
        LoadPlayerData(); // Load player data when the script starts
    }

    private void OnEnable()
    {
        xpManager = XpManager.Instance;

        if (xpManager == null)
        {
            Debug.LogError("XpManager is null. Called from PlayerLevel.cs");
        }

        xpManager.OnXpChange += HandleXpChange;
    }

    private void OnDisable()
    {
        xpManager.OnXpChange -= HandleXpChange;
        SavePlayerData(); // Save player data when the script is disabled
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

        // XP carries over to the next level
        totalXp -= maxXp;
        maxXp = CalculateMaxXp(currentLevel);

        SavePlayerData();

        UpdateDisplayLevel(); // Update the displayed level when the player levels up
        UpdateDisplayXP();
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

        UpdateDisplayLevel(); // Update the displayed level when loading player data
        UpdateDisplayXP();

        Debug.Log($"totalXp: {totalXp}, maxXp: {maxXp}, currentLevel: {currentLevel}");
    }

    private void UpdateDisplayLevel()
    {
        displayLevel.text = "Level: " + currentLevel.ToString(); // Update the displayed level
    }
    private void UpdateDisplayXP()
    {
        displayXP.text = totalXp.ToString() + "/" + maxXp.ToString(); // Update the XP Progress
        Debug.Log(displayXP.text);
        PlayerLevelBar playerLevelBar = GetComponent<PlayerLevelBar>();
        playerLevelBar.UpdateXpBar(totalXp, maxXp);
    }

    private int CalculateMaxXp(int level)
    {
        return level * 100 + 75;
    }

}
