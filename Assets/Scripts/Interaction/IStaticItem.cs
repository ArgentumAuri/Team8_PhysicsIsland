using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public interface IStaticItem
{
    public async Task Interact()
    {

    }

    public async Task Interact(Transform ItemInHand)
    {

    }

}
