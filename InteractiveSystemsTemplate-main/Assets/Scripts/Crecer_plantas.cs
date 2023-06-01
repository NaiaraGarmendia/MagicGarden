using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crecer_plantas : MonoBehaviour
{
    public float aumentoDeTamaño = 1.5f;

    private void OnTriggerEnter(Collider other){
        
        if(other.gameObject.CompareTag("Whater")){
            Transform crecer = other.gameObject.transform;
            crecer.localScale *= aumentoDeTamaño; 
            
        }
    }
  
}
