using System.Collections;
using UnityEngine;

public class Raycast_Pickup : MonoBehaviour
{
    [SerializeField] private float raycastDistance = 3f;
    [SerializeField] private LayerMask pickupLayer;
    [SerializeField] private string pickupTag = "Pickupable";
    [SerializeField] private Camera mainCam;

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
        // Cast a ray from the camera's position forward
        Ray ray = new Ray(mainCam.transform.position, mainCam.transform.forward);

        Debug.DrawRay(ray.origin, ray.direction * raycastDistance, Color.green);

        if (Physics.Raycast(ray, out RaycastHit hit, raycastDistance, pickupLayer))
        {
            if (hit.collider.CompareTag(pickupTag))
            {
                Debug.Log("Looking at " + hit.collider.gameObject.name);
                lookedAtObject = hit.collider.gameObject;
                DisplayText(false);

                if (Input.GetButtonDown("Fire1"))
                {
                    PickUpObject(hit.collider.gameObject);
                }
            }
        }
        //Throw
        if (Input.GetButtonDown("Fire1") && objectHeld)
        {
            ThrowObject();
            StartCoroutine(UpdateObjectHeld(false));
        }
        //Release
        if (Input.GetButtonDown("Fire2") && objectHeld)
        {
            ReleaseObject();
            StartCoroutine(UpdateObjectHeld(false));
        }
    }

    private void LateUpdate()
    {
        if (pickedObject != null)
        {
            UpdatePickedObjectPosition();
        }
    }





    private void DisplayText(bool picked)
    {
        if (!picked)
        {
            TranslateTextSettings(lookedAtObject.GetComponent<Pickupable>().settings);
        }
        else
        {

        }
    }

    private void TranslateTextSettings(TextSettings textSettings)
    {
//title
        dialogPannel.Title.text = textSettings.TextTitle;
        dialogPannel.Title.color = textSettings.TitleTextColor;
        dialogPannel.Title.fontSize = textSettings.TitleFontSize;
//body
        dialogPannel.Body.text = textSettings.TextBody;
        dialogPannel.Body.color = textSettings.BodyTextColor;
        dialogPannel.Body.fontSize = textSettings.BodyFontSize;

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

    private IEnumerator UpdateObjectHeld(bool state)
    {
        yield return new WaitForSeconds(0.4f);
        objectHeld = state;
    }
}
