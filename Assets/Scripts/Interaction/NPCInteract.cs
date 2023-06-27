using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCInteract : MonoBehaviour
{
    bool isFailed  = false;
    bool isSuccess = false;
    int currentStage  = 1;
    int currentPhrase = 0;
    int startRepeatIndex;
    int endRepeatIndex;
    int startStagePhrase;
    int successPhraseIndex;
    public AudioClip[] Clips;
    public string[] Phrases;
    public AudioSource audioSource;
    public GameObject dialogBox;
    Text text;
    private void Start()
    {
        text = dialogBox.GetComponentInChildren<Text>();
    }
    public void Dialog()
    {
        CurrentStage();
        dialogBox.SetActive(true);
        if(!isFailed && !isSuccess)
        {
            if (currentPhrase >= endRepeatIndex)
            {
                currentPhrase = startRepeatIndex;
            }
            ShowMessage(currentPhrase);
        }
        else if (isFailed)
        {

        }
        else if (isSuccess)
        {
            ShowMessage(successPhraseIndex);
            currentStage++;
            return;
        }
        currentPhrase++;
    }
    void ShowMessage(int index)
    {
        text.text = Phrases[index];
        if (Clips[index] != null)
        {
            audioSource.clip = Clips[index];
            audioSource.Play();
        }
    }
    void CurrentStage()
    {
        switch (currentStage) 
        {
            case 1:
                {
                    startStagePhrase = 0;
                    startRepeatIndex = 8;
                    endRepeatIndex = 10;
                }break;
            case 2: 
                {
                    startStagePhrase = 10;
                    startRepeatIndex = 10;
                    endRepeatIndex = 10;
                }
                break;
            case 3:
                {
                    startStagePhrase = 0;
                    startRepeatIndex = 0;
                    endRepeatIndex = 0;
                }
                break;
            case 4:
                {
                    startStagePhrase = 0;
                    startRepeatIndex = 0;
                    endRepeatIndex = 0;
                }
                break;
            case 5:
                {
                    startStagePhrase = 0;
                    startRepeatIndex = 0;
                    endRepeatIndex = 0;
                }
                break;
            case 6:
                {
                    startStagePhrase = Phrases.Length-1;
                    startRepeatIndex = Phrases.Length - 1;
                    endRepeatIndex = Phrases.Length - 1;
                }
                break;
        }
        if (currentPhrase < startStagePhrase)
            currentPhrase = startStagePhrase;
    }
}
