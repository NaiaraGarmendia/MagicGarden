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
    // graphical circle 
    private Transform GUITimer;

    public Camera UICamera;
    public Camera UICamera2;

    // Reference to the currently held item.
   
    private List<PickPackage> itemsPickedList = new List<PickPackage>();
    public bool pickedUp = false;

  

    bool RoutineOn = true;

    private void Start()
    {
        CanvasTimer.SetActive(false);
      
        //child of canvas is the graphical circle 
        GUITimer = CanvasTimer.transform.GetChild(0);
        StartCoroutine(CheckPosition());
    }


    // Update is called once per frame
    void Update()
    {
        

    }

   


     IEnumerator CheckPosition()
     {
         while (RoutineOn)
         {
             //Debug.Log("routine");
             Vector3 initPos = gameObject.transform.position;

             // Wait X seconds and take position again
             yield return new WaitForSeconds(0.3f);

             Vector3 nextPos = gameObject.transform.position;
             CanvasTimer.SetActive(false);

             //if position is the same then show counter
             if (Vector3.Distance(initPos, nextPos) < 0.5f)
             {
                // RoutineOn = false;
                 useTimer();
                
            }
         }

     }

    private void useTimer()
    {
        // Check if player picked some item already
        if (itemsPickedList.Count > 0)
        {
            // If yes, wait X seconds and drop
          
            PickPackage lastItem = itemsPickedList[itemsPickedList.Count - 1];
            if (lastItem.transform.position.z > 50) //change camera for ui timer display
            {
                SetUITimer(lastItem, UICamera);
            }
            else
            {
                SetUITimer(lastItem, UICamera2);
            }
      
            
           
            if (GUITimer.GetComponent<Timer>().timeRemaining < 0.3)
            {

                
     
                DropItem(lastItem);
                
                GUITimer.GetComponent<Timer>().StopTimer();
              
            
            }
           
          
          

        }
    }



   
    private void SetUITimer(PickPackage item, Camera camera)
    {
       
            Vector3 WorldtoScreenVec = camera.WorldToScreenPoint(item.transform.position);
            GUITimer.position = WorldtoScreenVec;
            CanvasTimer.GetComponent<Canvas>().targetDisplay = camera.targetDisplay;
            CanvasTimer.SetActive(true);
            GUITimer.GetComponent<Timer>().StartTimer();
            //Debug.Log("stopppuiii");

    }

  
    private void PickItem(PickPackage item)
    {
        // Assign reference
       
        SoundManager.Instance.Playpickup();
        itemsPickedList.Add(item);

        //Deactivate rotation if object has it
        if (item.GetComponent<Rotator>() != null)
        {
            item.GetComponent<Rotator>().enabled = false;
        }
        // Disable rigidbody and reset velocities
        item.Rb.isKinematic = true;
       

        item.Rb.velocity = Vector3.zero;
        item.Rb.angularVelocity = Vector3.zero;
        // Set Slot as a parent
        item.transform.SetParent(slot);
      
        // Reset position and rotation
        item.transform.localPosition = Vector3.zero;
        //item.transform.localEulerAngles = Vector3.zero;
        pickedUp = true;
        if (item.gameObject.CompareTag("seeds")){
            item.transform.GetComponent<Collider>().enabled = false;
        }
       
        
    }

    private void DropItem(PickPackage item)
    {
        SoundManager.Instance.Playdrop();
        CanvasTimer.SetActive(false);
        // Remove parent
        item.transform.SetParent(parent);

        //Deactivate rotation
        if (item.GetComponent<Rotator>() != null)
        {
            item.GetComponent<Rotator>().enabled = false;
        }

        item.transform.localPosition = new Vector3(item.transform.position.x,
            0.5f, item.transform.position.z);

        itemsPickedList.Remove(item);
        pickedUp = false;

        item.transform.GetComponent<Collider>().enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickpackage") || other.gameObject.CompareTag("shovel")|| other.gameObject.CompareTag("seeds") || other.gameObject.CompareTag("Water") )
        {
            PickItem(other.GetComponent<PickPackage>());
        }
    }
}
