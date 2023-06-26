using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlSettings : MonoBehaviour
{
    public Slider sensetivitySlider;
    public Text sensetivityText;
    private void Start()
    {
        sensetivitySlider.value = PlayerPrefs.GetFloat("Sensetivity");
    }
    public void SetSensetivity(float Sensetivity)
    {
        PlayerPrefs.SetFloat("Sensetivity", (float)System.Math.Round(Sensetivity, 2));
        PlayerPrefs.Save();
        sensetivityText.text = ((float)System.Math.Round(Sensetivity, 2)).ToString();
    }
}
