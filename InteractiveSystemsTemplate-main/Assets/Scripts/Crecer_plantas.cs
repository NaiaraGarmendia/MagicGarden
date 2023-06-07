using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crecer_plantas : MonoBehaviour
{
    //public float aumentoDeTamaño = 0.55f;  //1.5f;
    public Vector3 aumentoDeTamaño = new Vector3(0.5f, 0.5f, 0.5f);
    public Vector3 tamañoMaximo = new Vector3(3.0f, 3.0f, 3.0f);
    private void OnTriggerEnter(Collider other){

        if (other.gameObject.CompareTag("Water"))
        {
            Transform crecer = gameObject.transform;
            //if size equals limit plant doesn't grow 
            if (Vector3.Distance(crecer.localScale, tamañoMaximo) != 0) { 
                crecer.localScale += aumentoDeTamaño; 
                Debug.Log(crecer.localScale);
            }
            else
            {  //if this is not done then player can't harvest the plant
                gameObject.GetComponent<Collider>().isTrigger = false;

            }
        }
    }
  
}
