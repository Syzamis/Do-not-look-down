using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;


    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMasterVol();
            SetMusicVol();
            SetSfxVol();
        }
    }


    public void SetMasterVol()
    {
        float volume = masterSlider.value;
        mixer.SetFloat("Master", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("masterVolume", volume);
    }
    
    public void SetMusicVol()
    {
        float volume = musicSlider.value;
        mixer.SetFloat("Music", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("musicVolume", volume);

    }
    
    public void SetSfxVol()
    {
        float volume = sfxSlider.value;
        mixer.SetFloat("SFX", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("sfxVolume", volume);

    }


    private void LoadVolume()
    {
        masterSlider.value = PlayerPrefs.GetFloat("masterVolume");
        SetMasterVol();
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        SetMusicVol();
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
        SetSfxVol();
    }
    
    
}
