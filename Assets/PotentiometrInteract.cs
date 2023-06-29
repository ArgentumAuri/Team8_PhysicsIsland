using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PotentiometrInteract : MonoBehaviour, IStaticItem
{
    private Transform LLgic;
    private Transform Rotalka;
    public Vector3 currentRotation;
    public float TargetRotation;
    bool rotating = false;
    // Start is called before the first frame update
    void Start()
    {
        Rotalka = transform.GetChild(1);
        currentRotation = new Vector3(0,90,0);
        LLgic = GameObject.FindGameObjectWithTag("Laser").transform;
        LLgic.GetComponent<LineRenderer>().startWidth = 0.1f;
        LLgic.GetComponent<LineRenderer>().endWidth = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (rotating)
        {
            currentRotation.z += 100f * Time.fixedDeltaTime;
            currentRotation.z = Mathf.Clamp(currentRotation.z, 0, TargetRotation);
            Rotalka.localEulerAngles = currentRotation;
            if (currentRotation.z == TargetRotation) rotating = false;
        }
            LLgic.GetComponent<LineRenderer>().startWidth = (currentRotation.z / 100 + 0.1f);
            LLgic.GetComponent<LineRenderer>().endWidth = (currentRotation.z / 100 + 0.1f);

    }

    public async Task Interact()
    {
        if (GetComponent<ItemInteract>() == null)
        {
            TargetRotation += 30;
            if (TargetRotation > 300) TargetRotation = 0;
            rotating = true;
            LLgic.GetComponent<LineRenderer>().startWidth = (currentRotation.z / 100 + 0.1f);
            LLgic.GetComponent<LineRenderer>().endWidth = (currentRotation.z / 100 + 0.1f);
        }
    }
}
