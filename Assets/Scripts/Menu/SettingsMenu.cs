using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public MenuVariables settings;

    public AudioMixer audioMixerMusic;
    public AudioMixer audioMixerSound;

    public Dropdown resolutionDropdown;
    
    public PostProcessProfile postProcess;
    private ColorGrading m_ColorGrading;

    Resolution[] resolutions;

    public Text musicNumber;
    public Text effectNumber;
    public Text sensitivityNumber;
    public Text brightnessNumber;

    public Slider music;
    public Slider effect;
    public Slider sensitivity;
    public Slider brightness;
    public Dropdown resolution;
    public Dropdown quality;
    public Toggle fullscreen;


    private void Start()
    {
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

        m_ColorGrading = postProcess.GetSetting<ColorGrading>();

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        music.value = settings.musicVolume + 30;
        effect.value = settings.effectVolume + 30;
        sensitivity.value = settings.sensitivity;
        brightness.value = settings.brightness.x + 5;
        resolution.value = settings.resolutionIndex;
        quality.value = settings.qualityIndex;
        fullscreen.isOn = settings.isFullscreen;

        musicNumber.text = (settings.musicVolume /4 + 40).ToString();
        effectNumber.text = (settings.effectVolume /4 + 40).ToString();
        sensitivityNumber.text = settings.sensitivity.ToString();
        brightnessNumber.text = (settings.brightness.x + 5).ToString();

    }

    public void setResolution(int resolutionIndex)
    {
        settings.resolutionIndex = resolutionIndex;
        Resolution resolution = resolutions[settings.resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVolumeMusic(float volume)
    {
        settings.musicVolume = volume;
        settings.musicVolume = settings.musicVolume * 4 - 40;
        audioMixerMusic.SetFloat("Volume", settings.musicVolume);
        musicNumber.text = volume.ToString();
    }

    public void SetVolumeSound(float volume)
    {
        settings.effectVolume = volume;
        settings.effectVolume = settings.effectVolume * 4 - 40;
        audioMixerSound.SetFloat("Volume", settings.effectVolume);
        effectNumber.text = volume.ToString();
    }

    public void SetSensitivity(float sensitivity)
    {
        settings.sensitivity = sensitivity;
        sensitivityNumber.text = sensitivity.ToString();
    }

    public void SetBrightness(float brightness)
    {
        brightness -= 5;
        settings.brightness = new Vector4(brightness, brightness, brightness, brightness);
        m_ColorGrading.gain.value = settings.brightness;
        brightnessNumber.text = (brightness + 5).ToString();
    }

    public void SetQuality(int qualityIndex)
    {
        settings.qualityIndex = qualityIndex;
        QualitySettings.SetQualityLevel(settings.qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        settings.isFullscreen = isFullscreen;
        Screen.fullScreen = settings.isFullscreen;
    }

    public void ResetValue(string name)
    {
        switch(name)
        {
            case "Brightness":
                SetBrightness(6);
                brightness.value = settings.brightness.x + 5;
                break;
            case "Sensitivity":
                SetSensitivity(5);
                sensitivity.value = settings.sensitivity;
                break;
            case "Music":
                SetVolumeMusic(10);
                music.value = settings.musicVolume /4 + 40;
                break;
            case "Effect":
                SetVolumeSound(10);
                effect.value = settings.effectVolume /4 + 40;
                break;
        }
    }
}