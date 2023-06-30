using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCInteract : MonoBehaviour
{
    public bool isSuccess = false;
    public bool IsReadyToMove = false;

    public static int currentStage  = 1;
    public bool AnimatingNow = false;
    
    public string[] regularPhrases;
    int startRegularPhraseIndex;
    int endRegularPhraseIndex;
    int regularIndex=0;

    public string[] repeatPhrases;
    int startRepeatPhraseIndex;
    int endRepeatPhraseIndex;
    int repeatIndex=0;

    public string[] explanationPhrases;
    int startExplanationPhraseIndex;
    int endExplanationPhraseIndex;
    int explanationIndex=0;

    public AudioClip[] regularClips;
    public AudioClip[] repeatClips;
    public AudioClip[] explanationClips;
    public AudioSource audioSource;
    public GameObject dialogBox;
    public List<Transform> itemToSpawn;
    public GameObject playeritem;
    public Transform[] positions;
    Animator anim;
    Text text;

    private void Start()
    {
        positions[0] = gameObject.transform;
        text = dialogBox.GetComponentInChildren<Text>();
        anim = transform.GetComponent<Animator>();
    }
    public void Dialog()
    {
        if (AnimatingNow) return;
        CurrentStage();
        dialogBox.SetActive(true);
        Debug.Log(repeatIndex+" "+repeatIndex + " " + explanationIndex);
        if(!isSuccess)
        {
            if (regularIndex <= endRegularPhraseIndex)
            {
                if (regularIndex == 10)
                    SpawnObjects();
                //Debug.Log(regularPhrases[regularIndex], regularClips[regularIndex]);
                ShowMessage(regularPhrases[regularIndex], regularClips[regularIndex]);
                regularIndex++;
            }
            else if (repeatIndex <= endRepeatPhraseIndex)
            {
                if (repeatIndex == 14)
                    RespawnObjests();
                ShowMessage(repeatPhrases[repeatIndex], repeatClips[repeatIndex]);
                repeatIndex++;
                if (repeatIndex > endRepeatPhraseIndex)
                {
                    repeatIndex = startRepeatPhraseIndex;
                }
            }
        }
        else if (isSuccess && !IsReadyToMove)
        {
            ShowMessage(explanationPhrases[explanationIndex], explanationClips[explanationIndex]);
            explanationIndex++;
            if(playeritem.transform.childCount>0 && playeritem.transform.GetChild(0)!=null)
                TakeItem();
        }
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

    private void Update()
    {
        if (IsReadyToMove) 
        {
            gameObject.transform.position = positions[currentStage - 1].position;
            IsReadyToMove = false;
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
    void ShowMessage(string phrase,AudioClip clip)
    {
        gameObject.GetComponent<UIWriter>().typeText(text, phrase);
        Debug.Log(text.gameObject);
        if (clip != null)
        {
            audioSource.clip = clip;

            if (clip.name == "NPC explosion")
            {
                currentStage++;
                isSuccess = false;
            }
            anim.Play(clip.name);    
            audioSource.Play();
            
        }
        
    }
    void CurrentStage()
    {
        switch (currentStage) 
        {
            case 1:
                {
                    startRegularPhraseIndex     =0;
                    endRegularPhraseIndex       =7;
                    startRepeatPhraseIndex      =0;
                    endRepeatPhraseIndex        =4;
                    startExplanationPhraseIndex =0;
                    endExplanationPhraseIndex   =3;
}
                break;
            case 2: 
                {
                    startRegularPhraseIndex     =7;
                    endRegularPhraseIndex       =6;
                    startRepeatPhraseIndex      =5;
                    endRepeatPhraseIndex        =7;
                    startExplanationPhraseIndex =4;
                    endExplanationPhraseIndex   =6;
                }
                break;
            case 3:
                {
                    startRegularPhraseIndex     =9;
                    endRegularPhraseIndex       =14;
                    startRepeatPhraseIndex      =8;
                    endRepeatPhraseIndex        =14;
                    startExplanationPhraseIndex =7;
                    endExplanationPhraseIndex   =8;
                }
                break;
            case 4:
                {
                    isSuccess = false;
                    startRegularPhraseIndex     =16;
                    endRegularPhraseIndex       =0;
                    startRepeatPhraseIndex      =15;
                    endRepeatPhraseIndex        =15;
                    startExplanationPhraseIndex =100;
                    endExplanationPhraseIndex   =0;
                }
                break;
        }
        if (regularIndex < startRegularPhraseIndex)
            regularIndex = startRegularPhraseIndex;
        if(repeatIndex< startRepeatPhraseIndex) 
            repeatIndex = startRepeatPhraseIndex;
        if(explanationIndex< startExplanationPhraseIndex) 
            explanationIndex= startExplanationPhraseIndex;
    }
}
