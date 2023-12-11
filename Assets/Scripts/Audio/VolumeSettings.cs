using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

    private Transform knob; // Reference to the knob transform

    void Start()
    {
        knob = volumeSlider.transform.Find("Handle");

        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else
        {
            Load(); // Load the saved volume
            volumeSlider.onValueChanged.AddListener(delegate { Save(); }); // Listen for changes
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
        if (knob != null)
        {
            knob.localPosition = new Vector3(volumeSlider.value * volumeSlider.GetComponent<RectTransform>().rect.width, 0, 0);
        }
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
        PlayerPrefs.Save(); // Save the volume setting
    }
}
