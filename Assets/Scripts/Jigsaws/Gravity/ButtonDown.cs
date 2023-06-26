using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDown : MonoBehaviour, IStaticItem
{
    public bool Activated = false;
    public bool UseBlock = false;
    public Animator _anim;
    public Animator _ColbeAnim;

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
            if (Activated)
            {
                _ColbeAnim.Play("GlassCylynderUp");
            }
            else _ColbeAnim.Play("GlassCylynderDown");
        }
        return true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}


