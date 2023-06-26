using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteract : MonoBehaviour
{
    bool isMet = false;
    bool isFailed = false;

    public string GreetingPhrase;
    public string DisapointmentPhrase;
    public string[] RegularPhrases;
    public int repeatFrom = 2;
    private int currentPhrase = 0;
    public void Dialog()
    {
        if (!isMet)
        {
            isMet = true;
            //show dialog
            //text = GreetingPhrase
            return;
        }
        else if (isMet && !isFailed)
        {
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
            //show dialog
            // text = DisapointmentPhrase
        }
    }
}
