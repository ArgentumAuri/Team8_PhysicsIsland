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
    public AudioClip[] clips;
    public GameObject dialogBox;
    
    private void Update()
    {
        Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out hit, hitRange, _interactableMask);
        if (itemInHand.transform.childCount > 0 && Input.GetButton("DropItem") && hit.collider == null)
        {
            DropDown();
        }
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.GetComponentInParent<IStaticItem>() != null);
            if (Input.GetButtonDown("Interact"))
            {
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
                }
            }
        }
        if (hit.collider == null && Input.anyKey)
        {
            dialogBox.SetActive(false);
        }
    }
    private void PickUp(Transform interactable)
    {
        itemInHand.GetComponent<AudioSource>().clip = clips[0];
        itemInHand.GetComponent<AudioSource>().Play();
        interactable.SetParent(itemInHand, false);
        interactable.localPosition = Vector3.zero;
        interactable.localRotation = Quaternion.identity;
    }
    private void DropDown()
    {
        itemInHand.GetComponent<AudioSource>().clip = clips[1];
        itemInHand.GetComponent<AudioSource>().Play();
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
