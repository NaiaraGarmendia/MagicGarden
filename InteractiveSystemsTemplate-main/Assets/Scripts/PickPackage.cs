using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PickPackage : MonoBehaviour
{
    
    // Reference to the rigidbody
    private Rigidbody rb;
    public Rigidbody Rb => rb;
    /// <summary>
    /// Method called on initialization.
    /// </summary>
    private void Awake()
    {
        // Get reference to the rigidbody
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;

      
    }

}
