using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShellManager : MonoBehaviour
{
    public ShellDatabase shellDB;

    public Text nameText;
    public SpriteRenderer artworkSprite;

    private int selectedShell = 0;
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("selectedShell"))
        {
            selectedShell = 0;
        }
        else
        {
            Load();
        }
        UpdateShell(selectedShell);
    }
    public void NextOption()
    {
        selectedShell++;

        if(selectedShell >= shellDB.CharacterCount)
        {
            selectedShell = 0;
        }
        UpdateShell(selectedShell);
        Save();
    }
    public void BackOption()
    {
        selectedShell--;

        if(selectedShell <0)
        {
            selectedShell = shellDB.CharacterCount - 1;
        }
        UpdateShell(selectedShell);
        Save(); 
    }
    private void UpdateShell(int selectedShell)
    {
        Shells shells = shellDB.GetCharacter(selectedShell);
        artworkSprite.sprite = shells.shellSprite;
        // nameText.text = shells.shellName;
    }
    private void Load()
    {
        selectedShell = PlayerPrefs.GetInt("selectedShell");
    }
    private void Save()
    {
        PlayerPrefs.SetInt("selectedShell", selectedShell);
    }
    public void ChangeScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
