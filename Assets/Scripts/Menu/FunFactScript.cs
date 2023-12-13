using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FunFactScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI FunFactText;
    List<string> Prompts;

    void Start()
    {
        ReadPrompts();
        DisplayCurrentPrompt();
    }

    void ReadPrompts()
    {
        string[] prompts = System.IO.File.ReadAllLines(@"Assets\Scripts\Prompts.txt");
        Prompts = new List<string>(prompts);
    }

    void DisplayCurrentPrompt()
    {
        if (Prompts.Count > 0)
        {
            var RandomX = UnityEngine.Random.Range(0, Prompts.Count);
            // Debug.Log(Prompts[RandomX]);
            FunFactText.text = Prompts[RandomX];
        }
    }
}
