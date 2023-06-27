using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class GravityInterfaceButton : MonoBehaviour, IStaticItem
{
    public Material[] ButtonStates;
    public int ButtonState = 0;
    public TextMeshPro GForceValue;
    private int GForceInt;
    public int ButtonValue;
    public bool activated = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<MeshRenderer>().material = ButtonStates[ButtonState];
        
    }


    public async Task Interact()
    {
        if (!activated)
        {
            GetComponent<Animator>().Play("PlusButtonAnimPlay");
            GForceInt = int.Parse(GForceValue.text) + ButtonValue;
            if (GForceInt > 99) GForceInt = 99;
            if (GForceInt < 0) GForceInt = 0;
            GForceValue.text = (GForceInt).ToString();
        }
    }

    
}
