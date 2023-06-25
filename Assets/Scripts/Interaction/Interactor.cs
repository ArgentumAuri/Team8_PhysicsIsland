using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] public Transform _interactionPoint;
    [SerializeField] public float _interactionPointRadius = 0.5f;
    [SerializeField] public LayerMask _interactableMask;
    [SerializeField] public int _numFound;
    private readonly Collider[] _colliders = new Collider[3];
    private bool isPicked = false;


    private void Update()
    {
        _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders, _interactableMask);
        if (_numFound > 0 && _colliders[0].GetComponent<ItemInteract>())
        {
            if (isPicked && _interactionPoint.transform.childCount > 0 && Input.GetButton("Interact"))
            {
                DropDown();
            }
            else
            {
                var interactable = _colliders[0].GetComponent<ItemInteract>();
                if (interactable != null && Input.GetButton("Interact"))
                {
                    PickUp(interactable.gameObject);
                }
            }
        }
        if (_numFound > 0 && _colliders[0].GetComponentInParent<NPCInteract>() && Input.GetButton("Interact"))
        {
            var interactable = _colliders[0].gameObject.GetComponentInParent<NPCInteract>();
            interactable.Dialog();
        }
        //UnityEngine.Debug.Log(_colliders[0].gameObject.GetComponentInParent<NPCInteract>());
    }
    private void PickUp(GameObject interactable)
    {
        UnityEngine.Debug.Log(interactable.gameObject);
        interactable.transform.position = Vector3.zero;
        interactable.transform.rotation = Quaternion.identity;
        interactable.transform.SetParent(_interactionPoint, false);
        isPicked = true;
    }
    private void DropDown()
    {
        _interactionPoint.GetChild(0).SetParent(null);
        isPicked = false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
    }
}
