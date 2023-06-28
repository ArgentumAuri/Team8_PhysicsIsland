using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class LaserItemPlaceholder : MonoBehaviour, IStaticItem
{
    // Start is called before the first frame update
    void Start()
    {
        
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
            itemInHand.GetComponent<ItemInteract>().enabled = false;
            if (itemInHand.name == "fuse") itemInHand.localScale = new Vector3(2, 0.67f, 1);
            if (itemInHand.name == "Potentiometr") itemInHand.localScale = Vector3.one;
            if (itemInHand.name == "fuse") itemInHand.localScale = new Vector3(2, 0.67f, 1);
        }
    }
}
