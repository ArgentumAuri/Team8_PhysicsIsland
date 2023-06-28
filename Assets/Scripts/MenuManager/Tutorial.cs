using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public Image W,A,S,D,Q,E,SPACE,SHIFT;
    bool isPressedW, isPressedA, isPressedS, isPressedD, isPressedQ, isPressedE,isPressedShift, isPressedSpace;
    private void Update()
    {
        if (isPressedW && isPressedA && isPressedS && 
            isPressedD && isPressedQ && isPressedE && 
            isPressedShift && isPressedSpace) 
        { 
            gameObject.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            isPressedW =true;
            W.color = UnityEngine.Color.green;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            isPressedA = true;
            A.color = UnityEngine.Color.green;
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            isPressedS = true;
            S.color = UnityEngine.Color.green;
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            isPressedD = true;
            D.color = UnityEngine.Color.green;
        }
        else if(Input.GetKeyDown(KeyCode.Q))
        {
            isPressedQ = true;
            Q.color = UnityEngine.Color.green;
        }
        else if(Input.GetKeyDown(KeyCode.E))
        {
            isPressedE = true;
            E.color = UnityEngine.Color.green;
        }
        else if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            isPressedShift = true;
            SHIFT.color = UnityEngine.Color.green;
        }
        else if(Input.GetKeyDown(KeyCode.Space))
        {
            isPressedSpace = true;
            SPACE.color = UnityEngine.Color.green;
        }
    }
}
