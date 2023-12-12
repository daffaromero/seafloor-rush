using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character
{
    public string characterName;
    public Sprite characterSprite;
    public Sprite lockedSprite;
    public bool characterIsUnlocked;
    public int unlockLevel;
}
