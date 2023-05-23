using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabPackage : MonoBehaviour
{
    // Reference to the character camera.
    //[SerializeField]
    //private Camera characterCamera;

    // Reference to the slot for holding picked item.
    [SerializeField]
    private Transform slot;

    [SerializeField]
    private Transform parent;

    // Reference to the currently held item.
    //private PickPackage pickedItem;
    private List<PickPackage> itemsPickedList = new List<PickPackage>();

    //timer
    private float totalTime = 5.0f;
    //public float timeLeft = totalTime;
    float timer = 5.0f;
    // Update is called once per frame
    void Update()
    {
            
            // If no, try to pick item in front of the player
            // Create ray from center of the screen
           /* var ray = characterCamera.ViewportPointToRay(Vector3.one * 0.5f);
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
                    //PickItem(pickable);
                    PickItem(pickable);
                }
            }*/
        // Execute logic only on button pressed
        //if (Input.GetKeyDown(KeyCode.R))
        //{
        // Check if player picked some item already
         if (itemsPickedList.Count > 0) //(pickedItem)
         {
            // If yes, wait X seconds and drop
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                //DropItem(pickedItem);
                DropItem(itemsPickedList[itemsPickedList.Count - 1]);
                Debug.Log(itemsPickedList.Count);
                timer = totalTime;
            }
            

        }

       // }
        
      
        }


    private void PickItem(PickPackage item)//(PickPackage item)
    {
        // Assign reference
        //pickedItem = item;
        itemsPickedList.Add(item);
        // Disable rigidbody and reset velocities
        item.Rb.isKinematic = true;
        //item.Rb.detectCollisions = false;

        item.Rb.velocity = Vector3.zero;
        item.Rb.angularVelocity = Vector3.zero;
        // Set Slot as a parent
        item.transform.SetParent(slot);
      
        // Reset position and rotation
        item.transform.localPosition = Vector3.zero;
        item.transform.localEulerAngles = Vector3.zero;

       
        
    }

    private void DropItem(PickPackage item)
    {
        // Remove reference
        //pickedItem = null;
        // Remove parent
        item.transform.SetParent(parent);
        // Reset position and rotation
        //Vector3 newPosition = new Vector3(item.transform.localPosition.x, 1.1f, item.transform.localPosition.z);
        //item.transform.localPosition = newPosition;
        //Enable rigidbody
        //item.Rb.isKinematic = false;
        //item.Rb.detectCollisions= true;
        // Add force to throw item a little bit
        //item.Rb.AddForce(item.transform.forward * 2, ForceMode.VelocityChange);
        itemsPickedList.Remove(item);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickpackage") || other.gameObject.CompareTag("shovel"))
        {
            PickItem(other.GetComponent<PickPackage>());
        }
    }
}
