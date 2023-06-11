using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harvest : MonoBehaviour
{
    public GameObject corn;
    public GameObject tomato;
    public GameObject carrot;
    public Vector3 tamañomaximo;
    public Transform sueloTransform;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("plant"))
        {
            Debug.Log("enter");
            if(other.transform.localScale == tamañomaximo)
            {
             
                if(gameObject.transform.position.z < 27f){
                    GameObject Corn = Instantiate(corn, gameObject.transform.position,corn.transform.rotation);
                    other.gameObject.SetActive(false);
                }
                else if(gameObject.transform.position.z < 48f){
                    GameObject Carrot = Instantiate(carrot, gameObject.transform.position,carrot.transform.rotation);
                    other.gameObject.SetActive(false);
                }
                else{
                    GameObject Tomato = Instantiate(tomato, gameObject.transform.position, tomato.transform.rotation);
                    other.gameObject.SetActive(false);
                }
            }

        }
       
    }
}
