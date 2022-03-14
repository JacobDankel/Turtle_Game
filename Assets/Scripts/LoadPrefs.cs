using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LoadPrefs : MonoBehaviour
{
    [Header("General Settings")]
    [SerializeField] private bool canUse = false;
    [SerializeField] private MainMenuController menuController;

    [Header("Volume Settings")]
    [SerializeField] private TMP_Text volumeTextValue = null;
    [SerializeField] private Slider volumeSlider = null;

    [Header("Brightness Settings")]
    [SerializeField] private Slider brightnessSlider = null;
    [SerializeField] private TMP_Text brightnessTextValue = null;

    [Header("Quality level Settings")]
    [SerializeField] private TMP_Dropdown qualityDropdown;

    [Header("FullScreen Settings")]
    [SerializeField] private Toggle fullScreenToggle;

    [Header("Sensitivity Settings")]
    [SerializeField] private TMP_Text controllerSenTextValue = null;
    [SerializeField] private Slider controllerSenSlider = null;

    [Header("Invert Y Settings")]
    [SerializeField] private Toggle invertYToggle = null;


    private void Awake()
    {
        if (canUse)
        {
            if (PlayerPrefs.HasKey("masterVolume"))
            {
                float localVolume = PlayerPrefs.GetFloat("masterVolume");

                volumeTextValue.text = localVolume.ToString("0.0");
                volumeSlider.value = localVolume;
                AudioListener.volume = localVolume;
            }
            else
            {
                menuController.ResetButton("Audio");
            }
            if(PlayerPrefs.HasKey("masterQuality"))
            {
                int localQuality = PlayerPrefs.GetInt("masterQuality");
                qualityDropdown.value = localQuality;
                QualitySettings.SetQualityLevel(localQuality);
            }
            if(PlayerPrefs.HasKey("masterFullscreen"))
            {
                int localFullScreen = PlayerPrefs.GetInt("masterFullscreen");

                if (localFullScreen == 1)
                {
                    Screen.fullScreen = true;
                    fullScreenToggle.isOn = true;
                }
                else
                {
                    Screen.fullScreen = false;
                    fullScreenToggle.isOn = false;
                }
                if(PlayerPrefs.HasKey("masterBrightness"))
                {
                    float localBrightness = PlayerPrefs.GetFloat("masterBrightness");

                    brightnessTextValue.text = localBrightness.ToString("0.0");
                    brightnessSlider.value = localBrightness;
                    //Chnage The brightness
                }
                if (PlayerPrefs.HasKey("masterSen"))
                {
                    float localSensitivity = PlayerPrefs.GetFloat("masterSen");

                    controllerSenTextValue.text = localSensitivity.ToString("0");
                    controllerSenSlider.value = localSensitivity;
                    menuController.mainControllerSen = Mathf.RoundToInt(localSensitivity);
                }
                if (PlayerPrefs.HasKey("masterInvertY"))
                {
                    if(PlayerPrefs.GetInt("masterInvertY")==1)
                    {
                        invertYToggle.isOn = true;
                    }
                    else
                    {
                        invertYToggle.isOn = false;
                    }
                }
            }
        }
    }

}
