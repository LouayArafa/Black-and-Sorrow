using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public bool _IsInteractable = false;
    public bool _IsPickupable = false;
    public bool _IsStorable = false;


    [SerializeField] public TextSettings settings;

   
}
