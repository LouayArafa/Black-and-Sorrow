using System.Collections;
using UnityEngine;

public class Raycast_Pickup : MonoBehaviour
{
    [SerializeField] private float raycastDistance = 3f;
    [SerializeField] private LayerMask pickupLayer;
    [SerializeField] private string pickupTag = "Pickupable";
    [SerializeField] private Camera mainCam;
    [SerializeField] private float capsuleRadius = 0.5f; // Set your desired radius

    [SerializeField] private DialogPannel dialogPannel;
    
    public float throwForce = 10f;

    [SerializeField] private Vector3 offset;
    
    
    
    private GameObject pickedObject;
    private GameObject lookedAtObject;
    private bool objectHeld;

    private void Start()
    {
        if (mainCam == null)
        {
            Debug.LogError("MainCam not assigned to Raycast_Pickup script!");
        }
    }
    private void Update()
    {
        // Set up capsule cast parameters
        Vector3 capsuleStart = mainCam.transform.position;
        Vector3 capsuleEnd = mainCam.transform.position + mainCam.transform.forward * raycastDistance;

        // Perform capsule cast
        if (Physics.CapsuleCast(capsuleStart, capsuleEnd, capsuleRadius, mainCam.transform.forward, out RaycastHit hit, raycastDistance, pickupLayer))
        {
            if (hit.collider.CompareTag(pickupTag))
            {
                // Debug.Log("Looking at " + hit.collider.gameObject.name);
                lookedAtObject = hit.collider.gameObject;
            }
            else
            {
                lookedAtObject = null;
            }
        }
        else
        {
            lookedAtObject = null; // Set to null if there is no hit
        }

        // Debug draw the capsule cast
      
        DrawCapsule(capsuleStart, capsuleEnd, capsuleRadius, Color.green);

        test(lookedAtObject);
    }

    private void test(bool pg)
    {
        Debug.Log(pg);
    }
    private void DrawCapsule(Vector3 start, Vector3 end, float radius, Color color)
    {
        // Draw the center line
        Debug.DrawLine(start, end, color);

        // Draw the top and bottom circles
        Debug.DrawRay(start, Vector3.up * radius, color);
        Debug.DrawRay(start, Vector3.down * radius, color);
        Debug.DrawRay(end, Vector3.up * radius, color);
        Debug.DrawRay(end, Vector3.down * radius, color);

        // Draw the connecting lines between circles
        Debug.DrawRay(start + Vector3.up * radius, (end - start).normalized * radius, color);
        Debug.DrawRay(start - Vector3.up * radius, (end - start).normalized * radius, color);
        Debug.DrawRay(end + Vector3.up * radius, (start - end).normalized * radius, color);
        Debug.DrawRay(end - Vector3.up * radius, (start - end).normalized * radius, color);
    }

    /* private void LateUpdate()
     {
         if (pickedObject != null)
         {
             UpdatePickedObjectPosition();
         }
     }*/





    private void DisplayText(bool picked)
    {
        if (!picked)
        {
            TranslateTextSettings(lookedAtObject.GetComponent<InteractableObject>().settings, false);
        }
        else
        {
            TranslateTextSettings(lookedAtObject.GetComponent<InteractableObject>().settings, true);
        }
    }

    private void TranslateTextSettings(TextSettings textSettings, bool picked)
    {
        
            //title
        dialogPannel.Title.text = textSettings.TitleText_Look;
        dialogPannel.Title.color = textSettings.TitleTextColor_Look;
        dialogPannel.Title.fontSize = textSettings.TitleFontSize_Look;

        if (!picked)
        {
            //body
            dialogPannel.Body.text = textSettings.BodyText_Look;
            dialogPannel.Body.color = textSettings.BodyTextColor_Look;
            dialogPannel.Body.fontSize = textSettings.BodyFontSize_Look;
        }
        else
        {
            //body
            dialogPannel.Body.text = textSettings.BodyText_Pick;
            dialogPannel.Body.color = textSettings.BodyTextColor_Pick;
            dialogPannel.Body.fontSize = textSettings.BodyFontSize_Pick;
        }

    }

    private void PickUpObject(GameObject obj)
    {
        pickedObject = obj;
        pickedObject.GetComponent<Rigidbody>().useGravity = false;
        pickedObject.GetComponent<Collider>().enabled = false;
        pickedObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        pickedObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;



        StartCoroutine(UpdateObjectHeld(true));
    }

    private void ThrowObject()
    {
        pickedObject.GetComponent<Collider>().enabled = true;
        pickedObject.GetComponent<Rigidbody>().useGravity = true;

        pickedObject.transform.parent = null;
        pickedObject.GetComponent<Rigidbody>().AddForce(mainCam.transform.forward * throwForce, ForceMode.Impulse);
        pickedObject = null;
    }
    private void ReleaseObject()
    {
        pickedObject.GetComponent<Collider>().enabled = true;
        pickedObject.GetComponent<Rigidbody>().useGravity = true;
        pickedObject.transform.parent = null;
        pickedObject = null;
    }
    private void UpdatePickedObjectPosition()
    {
        pickedObject.transform.position = mainCam.transform.position + mainCam.transform.forward * offset.z + mainCam.transform.up * offset.y + mainCam.transform.right * offset.x;
        pickedObject.transform.Rotate(0.3f, 0.1f, 0.2f);
    }


    //to avoid spam picking 
    private IEnumerator UpdateObjectHeld(bool state)
    {
        yield return new WaitForSeconds(0.4f);
        objectHeld = state;
    }
}
