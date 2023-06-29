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
    public List<Transform> itemToSpawn;
    public GameObject playeritem;
    Text text;
    private void Start()
    {
        text = dialogBox.GetComponentInChildren<Text>();
    }
    public void Dialog()
    {
        CurrentStage();
        dialogBox.SetActive(true);
        Debug.Log(playeritem.GetComponentInChildren<Transform>());
        if(!isSuccess)
        {
            if (currentPhrase >= endRepeatIndex)
            {
                currentPhrase = startRepeatIndex;
            }
            ShowMessage(currentPhrase);

            if (currentPhrase == 17)
                SpawnObjects();
            if (currentPhrase == 20)
                RespawnObjests();
        }
        else if (isSuccess && playeritem.transform.GetChild(0))
        {

            TakeItem();
            ShowMessage(successPhraseIndex);
            currentStage++;
            isSuccess = false;
            return;
        }
        currentPhrase++;
    }

    void SpawnObjects()
    {
        foreach (Transform item in itemToSpawn)
        {
            item.gameObject.SetActive(true);
            item.GetComponent<Rigidbody>().isKinematic = false;
            item.SetParent(null);
            item.transform.localScale = Vector3.one;
        }
    }
    void RespawnObjests()
    {
        foreach (Transform item in itemToSpawn)
        {
            if(item.gameObject.GetComponent<ItemInteract>() != null)
                item.position = gameObject.transform.position;
        }
    }
    void TakeItem()
    {
        Transform item = playeritem.transform.GetChild(0);
        item.transform.SetParent(gameObject.transform);
        item.transform.rotation = Quaternion.identity;
        item.transform.localPosition= Vector3.zero;
        item.transform.localScale = Vector3.one;
        itemToSpawn.Add(item);
        item.gameObject.SetActive(false);
        
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
                    endRepeatIndex = 21;
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
