using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class LaserItemPlaceholder : MonoBehaviour, IStaticItem
{
    private LaserLogic LLGIC;
    // Start is called before the first frame update
    void Start()
    {
        LLGIC = GameObject.FindGameObjectWithTag("Laser").GetComponent<LaserLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async Task Interact(Transform itemInHand)
    {
        if (itemInHand.tag == "QuestItem" && transform.childCount == 0)
        {
            itemInHand.SetParent(transform);
            itemInHand.localPosition = Vector3.zero;
            itemInHand.localRotation = Quaternion.identity;
            Destroy(itemInHand.GetComponent<ItemInteract>());
            LLGIC.partsCount++;
        }
    }
}
