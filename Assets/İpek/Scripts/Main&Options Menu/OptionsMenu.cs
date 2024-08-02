using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;
    Resolution[] resolutions;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    private void Start()
    {
        // Resolution
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        // Initialize Sliders
        musicSlider.value = VolumeSettings.musicVolume;
        sfxSlider.value = VolumeSettings.soundEffectsVolume;

        musicSlider.onValueChanged.AddListener(HandleMusicSliderChange);
        sfxSlider.onValueChanged.AddListener(HandleSoundEffectsSliderChange);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreenMode);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    private void HandleMusicSliderChange(float value)
    {
        VolumeSettings.Instance.OnMusicSliderValueChange(value);
    }

    private void HandleSoundEffectsSliderChange(float value)
    {
        VolumeSettings.Instance.OnSoundEffectsSliderValueChange(value);
    }
}