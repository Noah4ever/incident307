using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionDetector : MonoBehaviour
{
    private List<IInteractable> _interactablesInRange = new List<IInteractable>();

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && _interactablesInRange.Count > 0)
        {
            IInteractable interactable = _interactablesInRange[0];
            interactable.Interact();
            if (!interactable.CanInteract())
            {
                _interactablesInRange.Remove(interactable);
            }
        }   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IInteractable interactable = collision.GetComponent<IInteractable>();
        if (interactable != null && interactable.CanInteract())
        {
            _interactablesInRange.Add(interactable);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        IInteractable interactable = collision.GetComponent<IInteractable>();
        if (interactable != null && _interactablesInRange.Contains(interactable))
        {
            _interactablesInRange.Remove(interactable);
        }
    }
}
