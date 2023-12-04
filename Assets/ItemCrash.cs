using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCrash : MonoBehaviour
{

    [SerializeField] private GameObject CrashedVersion;
    [SerializeField] private GameObject NormalVersion;
    [SerializeField] private float destructionThreshold = 5f; 

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision involves the picked object
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Calculate the collision velocity
            float collisionVelocity = collision.relativeVelocity.magnitude;

            // Define a threshold velocity for destruction

            // Check if the collision velocity is above the destruction threshold
            if (collisionVelocity > destructionThreshold)
            {
                NormalVersion.SetActive(false);
                CrashedVersion.SetActive(true);
                
            }
            else
            {
                // Do something else if the collision velocity is below the threshold
                Debug.Log("Object collided softly. No destruction.");
            }
        }
    }
}
