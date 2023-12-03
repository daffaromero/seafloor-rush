using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NameDisplayScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TMP_InputField displayName;
    void Start()
    {
        nameText.text = PlayerPrefs.GetString("user_name", "Player 1");
    }

    public void Create()
    {
        nameText.text = displayName.text;
        PlayerPrefs.SetString("user_name", nameText.text);
        PlayerPrefs.Save();
        displayName.text = displayName.placeholder.GetComponent<TextMeshProUGUI>().text;
    }
}
