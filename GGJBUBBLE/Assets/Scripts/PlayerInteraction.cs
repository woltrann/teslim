using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PlayerInteraction : MonoBehaviour
{
    public float PlayerReach = 3f;
    interactable CurrentInteractable;


    void Update()
    {
        CheckInteraction();
        if (Input.GetKeyDown(KeyCode.F) && CurrentInteractable != null)
        {
            CurrentInteractable.Interact();
        }
    }
    void CheckInteraction()
    {
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        if (Physics.Raycast(ray, out hit, PlayerReach))
        {
            if (hit.collider.tag == "Interactable")
            {
                interactable newInteractable = hit.collider.GetComponent<interactable>();
                if (CurrentInteractable && newInteractable != CurrentInteractable)
                {
                    CurrentInteractable.DisableOutline();
                }
                if (newInteractable.enabled)
                {
                    SetNewCurrentInteractable(newInteractable);
                }
                else
                {
                    DisableCurrentInteraction();
                }
            }
            else
            {
                DisableCurrentInteraction();
            }

        }
        else
        {
            DisableCurrentInteraction();
        }
    }



    private void SetNewCurrentInteractable(interactable newInteractable)
    {
        CurrentInteractable = newInteractable;
        CurrentInteractable.EnableOutline();
        HUDController.instance.EnableInteractionText(CurrentInteractable.message);
    }
    private void DisableCurrentInteraction()
    {
        HUDController.instance.DisableInteractionText();
        if (CurrentInteractable)
        {
            CurrentInteractable.DisableOutline();
            CurrentInteractable = null;
        }
    }

    

}
