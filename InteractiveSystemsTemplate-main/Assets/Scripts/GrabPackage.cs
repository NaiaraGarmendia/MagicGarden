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
    //private PickPackage pickedItem;
    private List<PickPackage> itemsPickedList = new List<PickPackage>();
    public bool pickedUp = false;
    //timer of UItimer
    //private float totalTime = 5.0f;
    //float timer = 5.0f;

    private void Start()
    {
        CanvasTimer.SetActive(false);
        //StartCoroutine(positionTimer());
        //child of canvas is the graphical circle 
        GUITimer = CanvasTimer.transform.GetChild(0);
    }


    // Update is called once per frame
    void Update()
    {
        StartCoroutine(positionTimer());

    }


    IEnumerator positionTimer()
    {
        Vector3 initPos = gameObject.transform.position;
      
        // Wait X seconds and take position again
        yield return new WaitForSeconds(3);
        //if (playerTimer < 0)
        //{
        Vector3 nextPos = gameObject.transform.position;
        CanvasTimer.SetActive(false);
        //if position is the same then show counter
        if (Vector3.Distance(initPos,nextPos) < 0.5f)
            {
            // Check if player picked some item already
            if (itemsPickedList.Count > 0)
                {
                    // If yes, wait X seconds and drop
                    //timer -= Time.deltaTime;
                    PickPackage lastItem = itemsPickedList[itemsPickedList.Count - 1];
                    if (lastItem.transform.position.z > 50) //change camera for ui timer display
                    {
                        SetUITimer(lastItem, UICamera);
                    }
                    else
                    {
                        SetUITimer(lastItem, UICamera2);
                    }
                    //Debug.Log(GUITimer.GetComponent<Timer>().GetRemainingSeconds()+"sec remaining");
                    if ( GUITimer.GetComponent<Timer>().GetRemainingSeconds() < 0.02 )
                    {

                        //DropItem(itemsPickedList[itemsPickedList.Count - 1]);
                        DropItem(lastItem);
                        Debug.Log("stoppp");
                       //timer = totalTime;
                        GUITimer.GetComponent<Timer>().StopTimer();

                    }
                }
            }
       // }

    }

    private void SetUITimer(PickPackage item, Camera camera)
    {
       
            Vector3 WorldtoScreenVec = camera.WorldToScreenPoint(item.transform.position);
            GUITimer.position = WorldtoScreenVec;
            CanvasTimer.GetComponent<Canvas>().targetDisplay = camera.targetDisplay;
            CanvasTimer.SetActive(true);
            GUITimer.GetComponent<Timer>().StartTimer();
            Debug.Log("stopppuiii");

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
