using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SettingsManager : MonoBehaviour {

    public Dropdown resolutionDropdown;
    public Dropdown textureQualityDropdown;
    public Toggle fullscreenToggle;

    public Resolution[] resolutions;
    public GameSettings gameSettings;

    void OnEnable()
    {
        gameSettings = new GameSettings();
        resolutions = Screen.resolutions;
      //  QualitySettings.masterTextureLimit = gameSettings.textureQuality = textureQualityDropdown.value;

        foreach(Resolution resolution in resolutions)
        {
            resolutionDropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
        }

        LoadSettings();
    }

    void OnDisable()
    {
        resolutionDropdown.options.Clear();
    }

    public void OnResolutionChange()
    {
        Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, Screen.fullScreen);
        gameSettings.resolutionIndex = resolutionDropdown.value;
        SaveSettings();
    }

    public void OnTextureQualityChange()
    {
        QualitySettings.masterTextureLimit = gameSettings.textureQuality = textureQualityDropdown.value;
        SaveSettings();
    }

    public void OnFullscreenToggle()
    {
        gameSettings.fullscreen = Screen.fullScreen = fullscreenToggle.isOn;
        SaveSettings();
    }

    public void SaveSettings()
    {
        string jsonData = JsonUtility.ToJson(gameSettings, true);
        File.WriteAllText(Application.persistentDataPath + "/gamesettings.json", jsonData);
    }

    public void LoadSettings()
    {
        gameSettings = JsonUtility.FromJson<GameSettings>(File.ReadAllText(Application.persistentDataPath + "/gamesettings.json"));

        resolutionDropdown.value = gameSettings.resolutionIndex;
        textureQualityDropdown.value = gameSettings.textureQuality;
        fullscreenToggle.isOn = gameSettings.fullscreen;

        resolutionDropdown.RefreshShownValue();
    }
}
