using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    float min = -80; float max = 0;
    public AudioMixer audioMixer;
    public Text TVtxt, PVtxt, EVtxt; 
    public Slider TVslider,PVslider,EVslider;

    private void Start()
    {
        TVslider.value = PlayerPrefs.GetFloat("TotalVolume");
        PVslider.value = PlayerPrefs.GetFloat("PlayerVolume");
        EVslider.value = PlayerPrefs.GetFloat("EnviromentVolume");
        TVtxt.text = ((int)toRange(min, max, TVslider.value, 0, 100)).ToString() + "%";
        PVtxt.text = ((int)toRange(min, max, PVslider.value, 0, 100)).ToString() + "%";
        EVtxt.text = ((int)toRange(min, max, EVslider.value, 0, 100)).ToString() + "%";
    }
    public void SetTotalVolume(float volume)
    {
        float value = toRange(min, max, TVslider.value, 0, 100);
        TVtxt.text = ((int)value).ToString()+"%";
        audioMixer.SetFloat("TotalVolume", volume);
        PlayerPrefs.SetFloat("TotalVolume", volume);
        PlayerPrefs.Save();
    }
    public void SetPlayerVolume(float volume)
    {
        float value = toRange(min, max, PVslider.value, 0, 100);
        PVtxt.text =((int)value).ToString() + "%";
        audioMixer.SetFloat("PlayerVolume", volume);
        PlayerPrefs.SetFloat("PlayerVolume", volume);
        PlayerPrefs.Save();
    }
    public void SetEnviromentVolume(float volume) 
    {
        float value = toRange(min, max, EVslider.value, 0, 100);
        EVtxt.text = ((int)value).ToString() + "%";
        audioMixer.SetFloat("EnviromentVolume", volume);
        PlayerPrefs.SetFloat("EnviromentVolume", volume);
        PlayerPrefs.Save();
    }
    private float toRange(float a, float b, float x, float A, float B) 
    {
        return ((x - a) / (b - a) * (B - A) + A);
    }
}
