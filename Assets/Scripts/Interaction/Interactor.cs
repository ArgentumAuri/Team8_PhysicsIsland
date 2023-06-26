using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Unity.Burst.CompilerServices;
using UnityEditor;
using UnityEngine;

public class Interactor : MonoBehaviour
{

    [SerializeField] public LayerMask _interactableMask;
    //raycast
    [SerializeField] [Min(1)] private float hitRange = 10;
    [SerializeField] public Transform playerCameraTransform;
    private RaycastHit hit;
    //interaction point
    [SerializeField] public Transform itemInHand;


    private void Update()
    {
        Debug.DrawRay(playerCameraTransform.position, playerCameraTransform.forward * hitRange, Color.red);
        Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out hit, hitRange, _interactableMask);
        if (itemInHand.transform.childCount > 0 && Input.GetButton("DropItem") && hit.collider == null)
        {
            DropDown();
        }
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.name);
            if (Input.GetButton("Interact"))
            {
                Debug.Log(hit.collider.gameObject.name);
                if (hit.collider.GetComponent<ItemInteract>())
                {
                    PickUp(hit.collider.gameObject.GetComponent<Transform>());
                    hit.collider.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                }
                else if (hit.collider.GetComponentInParent<NPCInteract>())
                {
                    hit.collider.GetComponentInParent<NPCInteract>().Dialog();
                }
                else
                {
                    hit.collider.GetComponentInParent<IStaticItem>()?.Interact();
                    Debug.Log("Олляля");
                }
            }
        }
    }
    private void PickUp(Transform interactable)
    {
        interactable.SetParent(itemInHand, false);
        interactable.localPosition = Vector3.zero;
        interactable.localRotation = Quaternion.identity;
    }
    private void DropDown()
    {
        Transform CurrentItem = itemInHand.GetChild(0);
        CurrentItem.SetParent(null);
        CurrentItem.GetComponent<Rigidbody>().isKinematic = false;
        CurrentItem.GetComponent<Rigidbody>().AddForce(transform.forward*1000f);
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(itemInHand.position, 0.5f);
    }
}
