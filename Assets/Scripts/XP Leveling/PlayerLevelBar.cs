using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;


public class PlayerLevelBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    public int totalXp;
    public int maxXp;
    public Image mask;
    void Update()
    {
        UpdateXpBar(totalXp, maxXp);
    }

    public void UpdateXpBar(float currentValue, float maxValue)
    {
        float fillAmount = (float)currentValue / (float)maxValue;
        mask.fillAmount = fillAmount;
    }
}
