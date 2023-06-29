using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCInteract : MonoBehaviour
{
    public bool isFailed  = false;
    public bool isSuccess = false;
    public static int currentStage  = 1;
    int currentPhrase = 0;
    int startRepeatIndex;
    int endRepeatIndex;
    int startStagePhrase;
    int successPhraseIndex;
    public AudioClip[] Clips;
    public string[] Phrases;
    public AudioSource audioSource;
    public GameObject dialogBox;
    public GameObject itemToSpawn;
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
            ShowMessage(0); //заменить при надобности
        }
        else if (isSuccess)
        {
            ShowMessage(successPhraseIndex);
            if (currentStage == 2)
            {
                Instantiate(itemToSpawn, gameObject.transform.position, gameObject.transform.rotation);
            }
            currentStage++;
            isSuccess = false;
            return;
        }
        currentPhrase++;
    }
    void ShowMessage(int index)
    {
        gameObject.GetComponent<UIWriter>().typeText(text,Phrases[index]);
        Debug.Log(text.gameObject);
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
                    successPhraseIndex = 11;
                    startStagePhrase = 0;
                    startRepeatIndex = 8;
                    endRepeatIndex = 10;
                }break;
            case 2: 
                {
                    successPhraseIndex = 16;
                    startStagePhrase = 12;
                    startRepeatIndex = 13;
                    endRepeatIndex = 15;
                }
                break;
            case 3:
                {
                    successPhraseIndex = 21;
                    startStagePhrase = 17;
                    startRepeatIndex = 18;
                    endRepeatIndex = 20;
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
