using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class LaserLogic : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;
    public LayerMask layerMask;
    public Transform LaserSpawn;
    private LineRenderer lineRenderer;
    public int nReflections = 0;
    private int nPoints;
    private Vector3 inDirection;
    int itemsInGrid = 0;
    public int partsCount;
    public bool ezz = false;
    
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (partsCount == 3)
        {
            las();
        }  
    }

    private void StartLaser()
    {
        ray = new Ray(LaserSpawn.position, LaserSpawn.forward);
        Physics.Raycast(LaserSpawn.position, LaserSpawn.forward, out hit, 1000f);

        if (hit.collider != null)
        {

            lineRenderer.SetPosition(0, LaserSpawn.position);
            lineRenderer.SetPosition(1, hit.point);
            lineRenderer.SetPosition(2, (Vector3.Reflect(ray.direction, hit.normal)));

        }
    }

    private void las()
    {
        //clamp the number of reflections between 1 and int capacity  
        nReflections = Mathf.Clamp(nReflections, 1, nReflections);
        //cast a new ray forward, from the current attached game object position  
        ray = new Ray(LaserSpawn.position, LaserSpawn.forward);

        //represent the ray using a line that can only be viewed at the scene tab  
        Debug.DrawRay(LaserSpawn.position, LaserSpawn.forward * 100, Color.magenta);

        //set the number of points to be the same as the number of reflections  
        nPoints = nReflections;
        //make the lineRenderer have nPoints  
        lineRenderer.SetVertexCount(nPoints);

        //Set the first point of the line at the current attached game object position  
        lineRenderer.SetPosition(0, LaserSpawn.position);

        for (int i = 0; i <= nReflections; i++)
        {
            //If the ray hasn't reflected yet  
            if (i == 0)
            {
                //Check if the ray has hit something  
                if (Physics.Raycast(ray.origin, ray.direction, out hit, 1000))//cast the ray 100 units at the specified direction  
                {
                    if (hit.collider.transform.gameObject.layer == 6)
                    {
                        inDirection = Vector3.Reflect(ray.direction, hit.normal);
                    }
                     
                    ray = new Ray(hit.point, inDirection);


                    //Print the name of the object the cast ray has hit, at the console  

                    //if the number of reflections is set to 1  
                    if (nReflections == 1)
                    {
                        //add a new vertex to the line renderer  
                        lineRenderer.SetVertexCount(++nPoints);
                    }

                    //set the position of the next vertex at the line renderer to be the same as the hit point  
                    lineRenderer.SetPosition(i + 1, hit.point);
                }
            }
            else // the ray has reflected at least once  
            {
                //Check if the ray has hit something  
                if (Physics.Raycast(ray.origin, ray.direction, out hit, 1000))//cast the ray 100 units at the specified direction  
                {
                    
                        //the refletion direction is the reflection of the ray's direction at the hit normal  
                        inDirection = Vector3.Reflect(inDirection, hit.normal);
                        //cast the reflected ray, using the hit point as the origin and the reflected direction as the direction  
                        ray = new Ray(hit.point, inDirection);

                        //Draw the normal - can only be seen at the Scene tab, for debugging purposes  
                        Debug.DrawRay(hit.point, hit.normal * 3, Color.blue);
                        //represent the ray using a line that can only be viewed at the scene tab  
                        Debug.DrawRay(hit.point, inDirection * 100, Color.magenta);

                        //Print the name of the object the cast ray has hit, at the console  
                        if (hit.transform.name == "OpenExit") ezz = true;
                    
                        //add a new vertex to the line renderer  
                        lineRenderer.SetVertexCount(++nPoints);
                        //set the position of the next vertex at the line renderer to be the same as the hit point  
                        lineRenderer.SetPosition(i + 1, hit.point);
                    
                    
                }
            }
        }
    }

}
