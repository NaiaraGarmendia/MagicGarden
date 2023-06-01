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

    public GameObject CanvasTimer;

    public Camera UICamera;
    public Camera UICamera2;

    // Reference to the currently held item.
    //private PickPackage pickedItem;
    private List<PickPackage> itemsPickedList = new List<PickPackage>();
    public bool pickedUp = false;
    //timer
    private float totalTime = 5.0f;
    //public float timeLeft = totalTime;
    float timer = 5.0f;

    private void Start()
    {
        CanvasTimer.SetActive(false);
    }


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
        if (itemsPickedList.Count > 0) 
         {
            // If yes, wait X seconds and drop
            timer -= Time.deltaTime;
            PickPackage lastItem = itemsPickedList[itemsPickedList.Count - 1];
            if (lastItem.transform.position.z > 50) //change camera for ui timer display
            {
                SetUITimer(lastItem,UICamera);
            }
            else
            {
                SetUITimer(lastItem, UICamera2);
            }

            if (timer < 0)
            {

                //DropItem(itemsPickedList[itemsPickedList.Count - 1]);
                DropItem(lastItem);
                timer = totalTime;
            }
            


        }
      

       // }
        
      
        }

    private void SetUITimer(PickPackage item, Camera camera)
    {      
            Transform GUITimer = CanvasTimer.transform.GetChild(0);
            Vector3 WorldtoScreenVec = camera.WorldToScreenPoint(item.transform.position);
            GUITimer.position = WorldtoScreenVec;
            CanvasTimer.GetComponent<Canvas>().targetDisplay = camera.targetDisplay;
           
            GUITimer.GetComponent<Timer>().StartTimer();
            CanvasTimer.SetActive(true);
    }

  
    private void PickItem(PickPackage item)//(PickPackage item)
    {
        // Assign reference
        //pickedItem = item;
        itemsPickedList.Add(item);

        //Deactivate rotation
        item.GetComponent<Rotator>().enabled = false;  

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
        pickedUp = true;
        if (item.gameObject.CompareTag("seeds")){
            item.transform.GetComponent<Collider>().enabled = false;
        }
       
        
    }

    private void DropItem(PickPackage item)
    {
        // Remove reference
        CanvasTimer.SetActive(false);
        //pickedItem = null;
        // Remove parent
        item.transform.SetParent(parent);

        //Deactivate rotation
        item.GetComponent<Rotator>().enabled = false;

        itemsPickedList.Remove(item);
        pickedUp = false;

        item.transform.GetComponent<Collider>().enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickpackage") || other.gameObject.CompareTag("shovel")|| other.gameObject.CompareTag("seeds") || other.gameObject.CompareTag("Whater") )
        {
            PickItem(other.GetComponent<PickPackage>());
        }
    }
}
