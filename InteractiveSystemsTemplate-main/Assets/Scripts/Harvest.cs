using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harvest : MonoBehaviour
{
    public GameObject verdura;
    public Vector3 tamañomaximo;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("plant"))
        {
            Debug.Log("enter");
            if(other.transform.localScale == tamañomaximo)
            {
                GameObject Flor = Instantiate(verdura, gameObject.transform.position, Quaternion.identity);
            }
           
        }
       
    }
}
