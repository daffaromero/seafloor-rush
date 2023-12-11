using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevelBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    public void UpdateXpBar(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;
    }
}
