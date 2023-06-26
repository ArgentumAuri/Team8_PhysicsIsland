using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDown : MonoBehaviour, IStaticItem
{
    public bool Activated = false;
    public bool UseBlock = false;
    public Animator _anim;

    void Start()
    {
        _anim = gameObject.GetComponent<Animator>();  
    }

    public bool Interact()
    {
        if (!UseBlock)
        {
            _anim.Play("interaction");
            Activated = !Activated;
            GetComponentInParent<GravityLogic>().StartRestart();
        }
        return true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}


