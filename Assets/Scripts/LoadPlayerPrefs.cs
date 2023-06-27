using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class LoadPlayerPrefs : MonoBehaviour
{
    public AudioMixer mixer;
    public GameObject player;
    void Start()
    {
        loadPlayerPrefs();
    }
    void loadPlayerPrefs()
    {
        //volume
        mixer.SetFloat("TotalVolume", PlayerPrefs.GetFloat("TotalVolume"));
        mixer.SetFloat("PlayerVolume", PlayerPrefs.GetFloat("PlayerVolume"));
        mixer.SetFloat("EnviromentVolume", PlayerPrefs.GetFloat("EnviromentVolume"));
        mixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("MusicVolume"));
        //sensetivity
        player.GetComponent<PlayerMovement>().SensetivityMultiplier = PlayerPrefs.GetFloat("Sensetivity");
    }
}
