using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : MonoBehaviour
{
    public bool _IsInteractable = true;

    [SerializeField] public TextSettings settings;

    private void Update()
    {
        if (!_IsInteractable)
            return;

    }
}
