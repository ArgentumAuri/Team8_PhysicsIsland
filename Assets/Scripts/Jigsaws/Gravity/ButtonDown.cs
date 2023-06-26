using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDown : MonoBehaviour, IStaticItem
{
    public Animator _anim;
    void Start()
    {
        _anim = gameObject.GetComponent<Animator>();  
    }

    public bool Interact()
    {
        _anim.Play("interaction");
        return true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}


