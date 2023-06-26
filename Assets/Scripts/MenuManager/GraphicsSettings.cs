using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphicsSettings : MonoBehaviour
{
    public Toggle toggleFullscreen;
    public Dropdown qualityDropdown;
    public Dropdown resolutionDropdown;
    Resolution[] resolutions;
    private void Start()
    {
        SetupResolution();
        SetupQuality();
    }
    private void SetupQuality() 
    {
        qualityDropdown.ClearOptions();
        List<string> qualityNames = new List<string>(QualitySettings.names);
        int curLevel = 0;
        for (int i = 0; i <= qualityNames.Count; i++)
        {
            if(QualitySettings.GetQualityLevel() == i)
                curLevel = i;
        }
        qualityDropdown.AddOptions(qualityNames);
        qualityDropdown.value = curLevel;
        qualityDropdown.RefreshShownValue();
    }
    private void SetupResolution()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> resolutionslist = new List<string>();
        int currentResIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string resolutionstr = resolutions[i].width + " x " + resolutions[i].height;
            resolutionslist.Add(resolutionstr);
            if (resolutions[i].width == Screen.currentResolution.width &&
               resolutions[i].height == Screen.currentResolution.height)
                currentResIndex = i;
        }
        resolutionDropdown.AddOptions(resolutionslist);
        resolutionDropdown.value = currentResIndex;
        resolutionDropdown.RefreshShownValue();
    }
    public void SetResolution(int resIndex)
    {
        Screen.SetResolution(resolutions[resIndex].width, resolutions[resIndex].height,Screen.fullScreen);
    }
    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    public void SetQuality(int qualIndex)
    {
        QualitySettings.SetQualityLevel(qualIndex);
    }
}
