using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plant : MonoBehaviour
{
    public GameObject florPrefab;
    public int TamañoFlor;

    private List<Vector3> posicionFlores; // Lista de posiciones de las parcelas creadas
    private Vector3 previousPosition;
    private int count;



    private void OnTriggerEnter(Collider other)
    {
    
        if (other.gameObject.CompareTag("seeds"))
        {
            
                Vector3 posicionPlant = new Vector3(other.transform.position.x,other.transform.position.y,other.transform.position.z);
                Debug.Log(posicionPlant + "posicionPlant");

            
                    // Instanciar la parcela en la posición calculada
                GameObject Flor = Instantiate(florPrefab, posicionPlant, Quaternion.identity);
                Flor.transform.localScale = new Vector3(TamañoFlor, 1f, TamañoFlor);
                Debug.Log(Flor.transform.position +"flor"); 
                other.gameObject.SetActive(false);


                   
            
        }
    }   
}
