using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NameDisplayScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI displayName;
    [SerializeField] private TMP_InputField inputName;

    void Start()
    {
        // Set the initial display name
        displayName.text = PlayerPrefs.GetString("user_name", "Player 1");

        // Subscribe to the onEndEdit event
        inputName.onEndEdit.AddListener(OnEndEdit);
    }

    private void OnEndEdit(string text)
    {
        // Save the input text to PlayerPrefs
        PlayerPrefs.SetString("user_name", text);
        PlayerPrefs.Save();

        // Update the display name
        displayName.text = PlayerPrefs.GetString("user_name", "Player 1");

        // Clear the input field text and show the placeholder
        inputName.text = "";
        inputName.placeholder.gameObject.SetActive(true);
    }
}
