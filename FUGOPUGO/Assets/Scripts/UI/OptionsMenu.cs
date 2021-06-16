using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.IO;
public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    Resolution[] resolutions;
    public Dropdown resolutionsDropdown;
    [SerializeField] Slider sliderVolume;
    [SerializeField] Toggle tooglefullscreen;
    [SerializeField] Dropdown dropdownQuality;
    private GameSettings gameSettings;
    string filePathSetting; 

    private void Awake()
    {
         
         gameSettings = new GameSettings();
        resolutions = Screen.resolutions;
        resolutionsDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionsDropdown.AddOptions(options);
        resolutionsDropdown.value = currentResolutionIndex;
        resolutionsDropdown.RefreshShownValue();
    }
    private void Start()
    {
         
        LoadSettings();
    }

   
    public void SetVolume()
    {
        audioMixer.SetFloat("volume", Mathf.Log10(sliderVolume.value)*20);
        gameSettings.volume = sliderVolume.value;
    }
    
   public void SetQuality(int quality)
   {
        QualitySettings.SetQualityLevel(quality);
        gameSettings.quality = quality;
   }

   public void SetFullScreen(bool isFullscreen)
   {
        Screen.fullScreen = isFullscreen;
        gameSettings.fullscreen = isFullscreen;
   }

   public void SetResolution(int resolutionIndex)
    {

       Resolution resolution = resolutions[resolutionIndex];
       Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
       gameSettings.resolution = resolutionIndex;
    }

    public void SaveSetting()
    {
        filePathSetting = Path.Combine(Application.persistentDataPath, "GameSetting.json");
        string jsonString = JsonUtility.ToJson(gameSettings, true); //Crea la stringa da salvare
        File.WriteAllText(filePathSetting, jsonString); //Salva la stringa sul file al percorso stabilito
    }

 
    // Funzione per deserializzare il file ed inserire i dati in playerDataObject
    public void LoadSettings()
    {
        filePathSetting = Path.Combine(Application.persistentDataPath, "GameSetting.json");
        
        
        if(File.Exists(filePathSetting) is true) {
            string jsonString = File.ReadAllText(filePathSetting); //Leggi il file
            gameSettings = JsonUtility.FromJson<GameSettings>(jsonString); 
            // Visual
            dropdownQuality.value = gameSettings.quality;
            resolutionsDropdown.value = gameSettings.resolution;
            tooglefullscreen.isOn = gameSettings.fullscreen;
            sliderVolume.value = gameSettings.volume;
            SetVolume();
            SetQuality(gameSettings.quality);
            SetFullScreen(gameSettings.fullscreen);
            SetResolution(gameSettings.resolution);
        }
        else if(!File.Exists(filePathSetting))
        {
            dropdownQuality.value = gameSettings.quality = 0;
            resolutionsDropdown.value = gameSettings.resolution = 0;
            tooglefullscreen.isOn = gameSettings.fullscreen = false;
            sliderVolume.value = gameSettings.volume = 1.0f;
            SetVolume();
            SetQuality(gameSettings.quality);
            SetFullScreen(gameSettings.fullscreen);
            SetResolution(gameSettings.resolution);
            SaveSetting();
        }
    }


}
