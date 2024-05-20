using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObject : MonoBehaviour, IInteractable
{
    public void BeginInteraction()
    {
        Debug.Log("Pick Up " + gameObject.name);
    }

    public void LeftClickAction()
    {
        Debug.Log(" throw " + gameObject.name);
    }

    public void OnHover()
    {
        Debug.Log("Hovering on " + gameObject.name);
    }

    public void RightClickAction()
    {
        Debug.Log("Release " + gameObject.name);
    }

  
}
