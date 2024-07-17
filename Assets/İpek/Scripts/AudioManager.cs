/*
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] private Image muteButtonImage;

    [SerializeField] private Sprite audioOnSprite;
    [SerializeField] private Sprite audioOffSprite;
    
    public const string prefAudioMute = "PrefAudioMute";
    
    [SerializeField] private AudioMixerGroup musicMixerGrup;
    [SerializeField] private AudioMixerGroup soundEffectsMixerGrup;
    [SerializeField] private Sound[] sounds;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        if (PlayerPrefs.HasKey(prefAudioMute))
            AudioListener.volume = PlayerPrefs.GetFloat(prefAudioMute);

        UpdateMuteButtonImage();

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.isLoop;
            s.source.playOnAwake = s.playOnAwake;
            s.source.volume = s.volume;

            switch (s.audioType)
            {
                case Sound.AudioTypes.soundEffect:
                    s.source.outputAudioMixerGroup = soundEffectsMixerGrup;
                    break;

                case Sound.AudioTypes.music:
                    s.source.outputAudioMixerGroup = musicMixerGrup;
                    break;
            }

            if (s.playOnAwake)
                s.source.Play();
            
        }
    }

    private void UpdateMuteButtonImage()
    {
        if (AudioListener.volume == 0)
            muteButtonImage.sprite = audioOffSprite;
        else
            muteButtonImage.sprite = audioOnSprite;
    }

    public void PlayClipByName(string _clipName)
    {
        Sound soundToPlay = Array.Find(sounds, dummySound => dummySound.clipName == _clipName);
        if (soundToPlay != null ) 
            soundToPlay.source.Play();
        
    }

    public void StopClipByName(string _clipName)
    {
        Sound soundToStop = Array.Find(sounds, dummySound => dummySound.clipName == _clipName);
        if (soundToStop != null)
            soundToStop.source.Stop();
    }

    public void UpdateMixerVolume()
    {
        musicMixerGrup.audioMixer.SetFloat("MusicVolume", Mathf.Log10(VolumeSettings.musicVolume) * 20);
        soundEffectsMixerGrup.audioMixer.SetFloat("SFXVolume", Mathf.Log10(VolumeSettings.soundEffectsVolume) * 20);
    }
    public void ToggleMute()
    {
        if (AudioListener.volume == 1)
            AudioListener.volume = 0;
        else
            AudioListener.volume = 1;
        
        PlayerPrefs.SetFloat(prefAudioMute, AudioListener.volume);
        PlayerPrefs.Save();
        UpdateMuteButtonImage();
    }
}
*/
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] private Image muteButtonImage;
    [SerializeField] private Sprite audioOnSprite;
    [SerializeField] private Sprite audioOffSprite;

    public const string prefAudioMute = "PrefAudioMute";

    [SerializeField] private AudioMixerGroup musicMixerGrup;
    [SerializeField] private AudioMixerGroup soundEffectsMixerGrup;
    [SerializeField] private Sound[] sounds;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        if (PlayerPrefs.HasKey(prefAudioMute))
            AudioListener.volume = PlayerPrefs.GetFloat(prefAudioMute);

        UpdateMuteButtonImage();

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.isLoop;
            s.source.playOnAwake = s.playOnAwake;
            s.source.volume = s.volume;

            switch (s.audioType)
            {
                case Sound.AudioTypes.soundEffect:
                    s.source.outputAudioMixerGroup = soundEffectsMixerGrup;
                    break;
                case Sound.AudioTypes.music:
                    s.source.outputAudioMixerGroup = musicMixerGrup;
                    break;
            }

            if (s.playOnAwake)
                s.source.Play();
        }
    }

    private void UpdateMuteButtonImage()
    {
        if (AudioListener.volume == 0)
            muteButtonImage.sprite = audioOffSprite;
        else
            muteButtonImage.sprite = audioOnSprite;
    }

    public void PlayClipByName(string _clipName)
    {
        Sound soundToPlay = Array.Find(sounds, dummySound => dummySound.clipName == _clipName);
        if (soundToPlay != null)
            soundToPlay.source.Play();
    }

    public void StopClipByName(string _clipName)
    {
        Sound soundToStop = Array.Find(sounds, dummySound => dummySound.clipName == _clipName);
        if (soundToStop != null)
            soundToStop.source.Stop();
    }

    public void UpdateMixerVolume()
    {
        musicMixerGrup.audioMixer.SetFloat("music_Vol_Par", Mathf.Log10(VolumeSettings.musicVolume) * 20);
        soundEffectsMixerGrup.audioMixer.SetFloat("sound_Vol_Par", Mathf.Log10(VolumeSettings.soundEffectsVolume) * 20);
    }

    public void ToggleMute()
    {
        if (AudioListener.volume == 1)
            AudioListener.volume = 0;
        else
            AudioListener.volume = 1;

        PlayerPrefs.SetFloat(prefAudioMute, AudioListener.volume);
        PlayerPrefs.Save();
        UpdateMuteButtonImage();
    }
}
