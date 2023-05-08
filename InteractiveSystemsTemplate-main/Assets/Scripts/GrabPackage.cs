using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabPackage : MonoBehaviour
{
    // Reference to the character camera.
    [SerializeField]
    private Camera characterCamera;

    // Reference to the slot for holding picked item.
    [SerializeField]
    private Transform slot;

    // Reference to the currently held item.
    private PickPackage pickedItem;
    //private List<PickPackage> pickItems;


    // Update is called once per frame
    void Update()
    {
        // Execute logic only on button pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
            // Check if player picked some item already
            if (pickedItem)
            {
                // If yes, drop picked item
                DropItem(pickedItem);
                //DropItem(pickItems[pickItems.Count - 1]);
            }

        }
        else
        {
            // If no, try to pick item in front of the player
            // Create ray from center of the screen
            var ray = characterCamera.ViewportPointToRay(Vector3.one * 0.5f);
            RaycastHit hit;
            // Shot ray to find object to pick
            if (Physics.Raycast(ray, out hit, 1.5f))
            {
                // Check if object is pickable
                var pickable = hit.transform.GetComponent<PickPackage>();
                // If object has PickaPackage class
                if (pickable)
                {
                    // Pick it
                    PickItem(pickable);
                }
            }
        }
    }


    private void PickItem(PickPackage item)
    {
        // Assign reference
        pickedItem = item;
        // Disable rigidbody and reset velocities
        item.Rb.isKinematic = false; //true
        
        item.Rb.velocity = Vector3.zero;
        item.Rb.angularVelocity = Vector3.zero;
        // Set Slot as a parent
        item.transform.SetParent(slot);
        item.Rb.detectCollisions = false;
        // Reset position and rotation
        item.transform.localPosition = Vector3.zero;
        item.transform.localEulerAngles = Vector3.zero;

        //pickItems.Add(pickedItem);
    }

    private void DropItem(PickPackage item)
    {
        // Remove reference
        pickedItem = null;
        // Remove parent
        item.transform.SetParent(null);
        // Enable rigidbody
        item.Rb.isKinematic = false;
        item.Rb.detectCollisions= false;
        // Add force to throw item a little bit
        //item.Rb.AddForce(item.transform.forward * 2, ForceMode.VelocityChange);
    }

}
