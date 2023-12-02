using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManagerScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreUI;
    // Start is called before the first frame update
    LogicScript ls;
    private void Start()
    {
        ls = LogicScript.Instance;
    }

    private void OnGUI() {
        scoreUI.text = ls.addScore();
    }
}
