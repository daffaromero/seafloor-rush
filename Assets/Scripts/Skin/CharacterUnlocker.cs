using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUnlocker : MonoBehaviour
{
    public CharacterDatabase characterDB;
    void Start()
    {
        UnlockCharacterBasedOnLevel();
    }

    private void UnlockCharacterBasedOnLevel()
    {
        int currentPlayerLevel = PlayerPrefs.GetInt("currentLevel", 1);

        foreach (Character character in characterDB.character)
        {
            if (currentPlayerLevel >= character.unlockLevel)
            {
                character.characterIsUnlocked = true;
            }
            else
            {
                character.characterIsUnlocked = false;
            }
        }
    }
}
