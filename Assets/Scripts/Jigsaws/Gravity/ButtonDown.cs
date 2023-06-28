using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ButtonDown : MonoBehaviour, IStaticItem
{
    public bool Activated = false;
    public bool UseBlock = false;
    public Animator _anim;
    public Animator _ColbeAnim;
    public bool ColbeAnim = false;
    private int startTimer;

    void Start()
    {
        _anim = gameObject.GetComponent<Animator>();  
    }

    public async Task Interact()
    {
        if (!UseBlock)
        {
            _anim.Play("interaction");

                Activated = !Activated;
            if (Activated)
            {
                GetComponentInParent<GravityLogic>().StartRestart();
                StartCoroutine(TimerCoroutine());
                

            }
            else
            {
                _ColbeAnim.Play("GlassCylynderUp");
                ColbeAnim = true;
                while (ColbeAnim)
                {
                    await Task.Yield();                   
                }
                GetComponentInParent<GravityLogic>().StartRestart();
            }
                
         
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator TimerCoroutine()
    {
        yield return new WaitForSeconds(Mathf.Ceil(5/(-GetComponentInParent<GravityLogic>().GForceValue*10)));

        _ColbeAnim.Play("GlassCylynderDown");
    }
}


