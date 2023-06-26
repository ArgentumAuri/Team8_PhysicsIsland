using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FallingBoxScript : MonoBehaviour
{
    Vector3 velocity;
    public float gForce;
    private Rigidbody rb;
    Vector3 gForceVector;
    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gForceVector = new Vector3(0f, gForce, 0f);
        Vector3 newVelocity = rb.velocity + gForceVector * rb.mass * Time.deltaTime;
        Debug.Log(rb.velocity);
        rb.velocity = newVelocity;
    }
}
