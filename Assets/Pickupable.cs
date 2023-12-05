using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : MonoBehaviour
{

    public bool _IsLookedAt = false;
    public bool _IsPickedUp = false;
    public bool _IsInteractable = true;

    [SerializeField] private TextSettings settings;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
