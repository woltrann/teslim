using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
public class interactable : MonoBehaviour
{
    Outline outline;
    public string message;

    public UnityEvent onInteraction;
    void Start()
    {
        outline = GetComponent<Outline>();
        DisableOutline();
    }

    public void Interact()
    {
        onInteraction.Invoke();
    }
    public void DisableOutline()
    {
        outline.enabled = false;
    }
    public void EnableOutline()
    {
        outline.enabled = true;
    }
}
