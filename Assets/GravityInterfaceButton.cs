using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class GravityInterfaceButton : MonoBehaviour, IStaticItem
{
    public Material[] ButtonStates;
    public int ButtonState = 0;
    bool activated = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<MeshRenderer>().material = ButtonStates[ButtonState];
        
    }


    public bool Interact()
    {

            GetComponent<Animator>().Play("PlusButtonAnimPlay");
            Debug.Log("Ezz");
            return true;
        
    }

    
}
