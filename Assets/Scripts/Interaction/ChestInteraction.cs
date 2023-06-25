using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour, IStaticItem
{
    public bool Interact()
    {
        var test = this.GetComponentInParent<Transform>();
        return true;
    }
}
