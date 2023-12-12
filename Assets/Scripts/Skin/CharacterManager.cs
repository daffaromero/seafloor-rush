using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public CharacterDatabase characterDB;

    public TextMeshProUGUI nameText;
    public SpriteRenderer artworkSprite;
    private int viewedOption = 0;
    private int selectedOption = 0;
    private int prevSelectedUnlockedChar = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("selectedOption"))
        {
            viewedOption = 0;
            selectedOption = 0;
            prevSelectedUnlockedChar = 0;
        }
        else
        {
            Load();
            viewedOption = selectedOption;
            prevSelectedUnlockedChar = selectedOption;
        }
        UpdateCharacter(selectedOption);
    }

    public void NextOption()
    {
        viewedOption++;

        LoopOption();
        CheckAndUpdate();
        Save();
    }

    public void BackOption()
    {
        viewedOption--;

        LoopOption();
        CheckAndUpdate();
        Save();
    }

    private void LoopOption()
    {
        if (viewedOption >= characterDB.CharacterCount)
        {
            viewedOption = 0;
        }
        else if (viewedOption < 0)
        {
            viewedOption = characterDB.CharacterCount - 1;
        }
    }

    private void CheckAndUpdate()
    {
        if (!IsCharacterUnlocked(viewedOption))
        {
            UpdateCharacter(viewedOption);
            selectedOption = prevSelectedUnlockedChar;
        }
        else
        {
            UpdateCharacter(viewedOption);
            prevSelectedUnlockedChar = viewedOption;
            selectedOption = viewedOption;
        }
    }

    private bool IsCharacterUnlocked(int characterIndex)
    {
        Character character = characterDB.GetCharacter(characterIndex);
        bool isUnlocked = character.characterIsUnlocked;

        if (isUnlocked)
        {
            Debug.Log($"Character {characterIndex} with name {character.characterName} is unlocked");
            prevSelectedUnlockedChar = characterIndex;
        }
        else
        {
            Debug.Log($"Character {characterIndex} with name {character.characterName} is locked");
        }

        return isUnlocked;
    }

    private void UpdateCharacter(int viewedOption)
    {
        Character character = characterDB.GetCharacter(viewedOption);

        if (IsCharacterUnlocked(viewedOption))
        {
            artworkSprite.sprite = character.characterSprite;
            nameText.text = character.characterName;
        }
        else
        {
            artworkSprite.sprite = character.lockedSprite;
            nameText.text = $"Reach level {character.unlockLevel} to unlock";
        }
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }

    private void Save()
    {
        PlayerPrefs.SetInt("selectedOption", selectedOption);
    }

    public void ChangeScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
