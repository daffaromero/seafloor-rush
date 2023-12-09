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

    private int selectedOption = 0;
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }
        else
        {
            Load();
        }
        UpdateShell(selectedOption);
    }
    public void NextOption()
    {
        selectedOption++;

        if(selectedOption >= shellDB.CharacterCount)
        {
            selectedOption = 0;
        }
        UpdateShell(selectedOption);
        Save();
    }
    public void BackOption()
    {
        selectedOption--;

        if(selectedOption <0)
        {
            selectedOption = shellDB.CharacterCount - 1;
        }
        UpdateShell(selectedOption);
        Save(); 
    }
    private void UpdateShell(int selectedOption)
    {
        Shells shells = shellDB.GetCharacter(selectedOption);
        artworkSprite.sprite = shells.shellSprite;
        nameText.text = shells.shellName;
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
