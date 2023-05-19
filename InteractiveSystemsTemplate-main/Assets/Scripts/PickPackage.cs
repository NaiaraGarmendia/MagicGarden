using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PickPackage : MonoBehaviour
{
    
    // Reference to the rigidbody
    private Rigidbody rb;
    public Rigidbody Rb => rb;

    private Collider cl;
    public Collider Cl => cl;
    /// <summary>
    /// Method called on initialization.
    /// </summary>
    private bool dropdown;
    private void Awake()
    {
        // Get reference to the rigidbody
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;

        cl = GetComponent<Collider>();
        cl.enabled = true;
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //dropdown = true;
            Destroy(cl);
        }
    }
    

    private void OnTriggerExit(Collider other)
    {
        _ = gameObject.AddComponent<MeshCollider>();
    }*/
}
