using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting.AssemblyQualifiedNameParser;
using UnityEngine;

public class ChestButtonDown : MonoBehaviour, IStaticItem
{
    public bool IsAnimating;
    public Animator ChestAnimator;
    public GameObject npc;
    public GameObject item;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async Task Interact()
    {
        if (!IsAnimating && !ChestAnimator.GetCurrentAnimatorStateInfo(0).IsName("Chest Open"))
        {
            ChestAnimator.Play(gameObject.name);
            IsAnimating = true;
            while (IsAnimating)
            {
                await Task.Yield();
            }
            if (gameObject.name == "MoonButton" && NPCInteract.currentStage==2) 
            {
                ChestAnimator.Play("Chest Open");
                npc.GetComponent<NPCInteract>().isSuccess = true;
                item.SetActive(true);
                gameObject.GetComponent<AudioSource>().Play();
                
            }
        }
    }
}
