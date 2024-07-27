using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VolumeSettings : MonoBehaviour
{
    public static VolumeSettings Instance { get; private set; }
    public static float musicVolume { get; private set; }
    public static float soundEffectsVolume { get; private set; }

    [SerializeField] private TextMeshProUGUI musicSliderText;
    [SerializeField] private TextMeshProUGUI soundEffectsSliderText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // Set default values if not already set
            if (!PlayerPrefs.HasKey("MusicVolume"))
                PlayerPrefs.SetFloat("MusicVolume", 0.5f);
            if (!PlayerPrefs.HasKey("SFXVolume"))
                PlayerPrefs.SetFloat("SFXVolume", 0.5f);

            musicVolume = PlayerPrefs.GetFloat("MusicVolume");
            soundEffectsVolume = PlayerPrefs.GetFloat("SFXVolume");
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    public void OnMusicSliderValueChange(float value)
    {
        musicVolume = value;
        PlayerPrefs.SetFloat("MusicVolume", value);
        musicSliderText.text = ((int)(value * 100)).ToString();
        AudioManager.Instance.UpdateMixerVolume();
    }

    public void OnSoundEffectsSliderValueChange(float value)
    {
        soundEffectsVolume = value;
        PlayerPrefs.SetFloat("SFXVolume", value);
        soundEffectsSliderText.text = ((int)(value * 100)).ToString();
        AudioManager.Instance.UpdateMixerVolume();
    }
}
