using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable 
{
    public void OnHover();
    public void BeginInteraction();
    public void LeftClickAction();
    public void RightClickAction();

}
