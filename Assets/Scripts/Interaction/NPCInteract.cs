using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteract : MonoBehaviour
{
    bool isMet = false;
    bool isFailed = false;
    public AudioClip[] clips;
    private AudioSource audioSource;
    public string GreetingPhrase;
    public string DisapointmentPhrase;
    public string[] RegularPhrases;
    public int repeatFrom = 2;
    private int currentPhrase = 0;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Dialog()
    {
        if (!isMet)
        {
            isMet = true;
            PlayClip(0);
            //show dialog
            //text = GreetingPhrase
            return;
        }
        else if (isMet && !isFailed)
        {
            PlayClip(1);
            //show dialog
            //if (currentPhrase<RegularPhrases.length)
            // text = RegularPhrases[currentPhrase]
            //else 
            // {
            // currentPhrase = repeatFrom;
            // text = RegularPhrases[currentPhrase]
            // }
        }
        else if (isFailed)
        {
            PlayClip(2);
            //show dialog
            // text = DisapointmentPhrase
        }
    }
    void PlayClip(int i)
    {
        audioSource.clip = clips[i];
        audioSource.Play();
    }    
}
