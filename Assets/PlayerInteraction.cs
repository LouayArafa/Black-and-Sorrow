using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    [SerializeField] private IInteractable current_InteractableObject;
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.GetComponent<IInteractable>() != null)
        {
            IInteractable interactable = other.gameObject.GetComponent<IInteractable>();
            
            
            interactable.OnHover();


            if (Input.GetButtonDown("Fire1") && current_InteractableObject == null){
                interactable.BeginInteraction();
                current_InteractableObject = interactable;
            }
            if (current_InteractableObject!= null)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    current_InteractableObject.LeftClickAction();
                    current_InteractableObject = null;
                }
                    
                if (Input.GetButtonDown("Fire2"))
                {
                    current_InteractableObject.RightClickAction();
                    current_InteractableObject = null;
                }
                    
            }

        }
    }
}
