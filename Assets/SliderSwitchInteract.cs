using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class SliderSwitchInteract : MonoBehaviour, IStaticItem
{
    private bool active = false;
    public bool isAnimated = false;
    private Animator anim;
    public Transform LLgic;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        LLgic = GameObject.FindGameObjectWithTag("Laser").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async Task Interact()
    {
        if (GetComponent<ItemInteract>() == null && !isAnimated)
        {
            active = !active;
            if (!active)
            {
                anim.Play("SwitchOff");
                LLgic.GetComponent<LaserLogic>().enabled = false;
                LLgic.GetComponent<LineRenderer>().enabled = false;

            }
            else
            {
                anim.Play("SwitchOn");
                LLgic.GetComponent<LaserLogic>().enabled = true;
                LLgic.GetComponent<LineRenderer>().enabled = true;
            }
        }
    }
}
