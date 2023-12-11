using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;


public class PlayerLevelBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    public void Start()
    {
        
    }
    public void UpdateXpBar(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;
    }
}
