using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class BilboardController : MonoBehaviour
{
    public Texture[] Maps;
    public int i = 0;
    public MeshRenderer mr;
    
    // Start is called before the first frame update
    void Start()
    {
        mr = transform.GetChild(2).GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        mr.material.SetTexture("_BaseMap", Maps[NPCInteract.currentStage-1]);
    }

}
