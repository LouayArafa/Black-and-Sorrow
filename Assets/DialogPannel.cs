using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogPannel : MonoBehaviour
{


  /*  #region Singleton instance
    public static DialogPannel Instance { get; private set; }

    private void Awake()
    {
        // Ensure only one instance of the DialogPannel exists
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion */


    [SerializeField] public TextMeshProUGUI Title;
    [SerializeField] public TextMeshProUGUI Body;

    [SerializeField] private TextSettings CurrentText = null;

}