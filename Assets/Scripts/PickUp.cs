using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Camera cam;
    public Vector3 offset;
    public float throwForce = 10f;
    private GameObject pickedObject;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == ("PickUp"))
        {
            if (Input.GetKey(KeyCode.F))
            {
                pickedObject = other.gameObject;
                pickedObject.GetComponent<Rigidbody>().useGravity = false;
                gameObject.GetComponent<Collider>().enabled= false;

            }
        }
    }

    private void Update()
    {
        if (pickedObject != null && Input.GetKeyUp(KeyCode.F))
        {
            pickedObject.GetComponent<Rigidbody>().useGravity = true;
            pickedObject.transform.parent = null;
            pickedObject.GetComponent<Rigidbody>().AddForce(cam.transform.forward * throwForce, ForceMode.Impulse);
            pickedObject = null;
            gameObject.GetComponent<Collider>().enabled = true;

        }
        if (pickedObject != null)
        {
            pickedObject.transform.position = cam.transform.position + cam.transform.forward * offset.z + cam.transform.up * offset.y + cam.transform.right * offset.x;
            pickedObject.transform.Rotate(0.3f, 0.1f, 0.2f);

        }
    }
}
