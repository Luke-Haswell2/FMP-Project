using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Menu : MonoBehaviour
{
    [SerializeField] AudioMixer mixerMusic;
    [SerializeField] AudioMixer mixerSFX;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;

    public string MIXER_MUSIC = "MusicVolume";
    public string MIXER_SFX = "SFXVolume";

    public Toggle musictoggle;

    void Start()
    {
        SetVolumeMusic(PlayerPrefs.GetFloat(MIXER_MUSIC));
        SetVolumeSFX(PlayerPrefs.GetFloat(MIXER_SFX));
    }
    void Update()
    {
        PlayerPrefs.SetFloat(MIXER_MUSIC, musicSlider.value);
        PlayerPrefs.SetFloat(MIXER_SFX, sfxSlider.value);
    }
    public void SetVolumeMusic(float volume)
    {
        musicSlider.value = volume;

        mixerMusic.SetFloat("Volume", volume);
    }
    public void SetVolumeSFX(float volume)
    {
        sfxSlider.value = volume;

        mixerSFX.SetFloat("Volume", volume);
    }
    public void ToggleMusic(int logic)
    {
        if (musictoggle.isOn == true)
        {
            logic = 1;
            musicSlider.interactable = true;
            SetVolumeMusic(0.5f);
        }
        else if (musictoggle.isOn == false)
        {
            logic = 0;
            musicSlider.interactable = false;
            SetVolumeMusic(-60);
        }
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
