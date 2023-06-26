using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphicsSettings : MonoBehaviour
{
    public Toggle toggleFullscreen;
    public Dropdown resolutionDropdown;
    public void FullScreenModeChanged()
    {
        Screen.fullScreen = toggleFullscreen.isOn;
    }
    public void ResolutionChanged()
    {
        string[] resStr = resolutionDropdown.options[resolutionDropdown.value].text.Split('x');
        int width  = int.Parse(resStr[0]);
        int height = int.Parse(resStr[1]);
        Screen.SetResolution(width, height,bool.Parse(toggleFullscreen.isOn.ToString()));
    }
}
