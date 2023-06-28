using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GravityLogic : MonoBehaviour
{

    public TextMeshPro GForcePanel;
    public float GForceValue;
    public ButtonDown ActivateButton;
    public GameObject CrateToSpawn;
    public GameObject PrizeFuse;
    public MeshCollider HoleForCrate;
    public Transform CrateSpawnPoint;
    public Transform FuseSpawnPoint;
    public Transform ActualCrate;
    private bool GOTOVO = false;
    public GameObject npc;
    // Start is called before the first frame update
    void Start()
    {
        StartRestart();
    }

    // Update is called once per frame
    void Update()
    {
        GForceValue = (float)-int.Parse(GForcePanel.text)/10f;
    }

    public void StartRestart()
    {

            if (!ActivateButton.Activated)
            {
                HoleForCrate.enabled = true;
                if (ActualCrate != null) Destroy(ActualCrate.gameObject);
                ActualCrate = Instantiate(CrateToSpawn, CrateSpawnPoint).transform;
                ActualCrate.localPosition = Vector3.zero;
                ActualCrate.localEulerAngles = CrateSpawnPoint.localEulerAngles;

            }
            else
            {
                ActualCrate.GetComponent<FallingBoxScript>().gForce = GForceValue;
                HoleForCrate.enabled = false;
            }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (int.Parse(GForcePanel.text) > 37 && int.Parse(GForcePanel.text) < 43 && other.name == "BoxToBreak Variant(Clone)" && !GOTOVO)
        {
            Destroy(ActualCrate.gameObject);
            Instantiate(PrizeFuse,FuseSpawnPoint);
            PrizeFuse.GetComponent<Rigidbody>().isKinematic = false;
            PrizeFuse.transform.localPosition = Vector3.zero;
            //PrizeFuse.transform?.SetParent(null);
            GOTOVO = true;
            npc.GetComponent<NPCInteract>().isSuccess = true;
        }

        else if (int.Parse(GForcePanel.text) >= 43)
        {
            Destroy(ActualCrate.gameObject);
        }
    }
}
