using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regar_hierba : MonoBehaviour
{
    public GameObject prefabHierba; // Prefab de la parcela
    public int TamañoHierba; // Tamaño de la parcela
    

    private List<Vector3> posicionHierbas; // Lista de posiciones de las parcelas creadas
    private Vector3 previousPosition;

   


    private void Start()
    {
        posicionHierbas = new List<Vector3>();
        previousPosition = transform.position;
    }

    private void OnTriggerStay(Collider other)
    {
        
        
        if (other.CompareTag("Whater"))
        {
            
          
            Vector3 HierbaPosicion = new Vector3(other.transform.position.x,other.transform.position.y,other.transform.position.z);
        


            // Verificar si la posición de la parcela ya ha sido registrada
            if (!posicionHierbas.Contains(HierbaPosicion))
            {
                // Instanciar la parcela en la posición calculada
                GameObject hierba = Instantiate(prefabHierba, HierbaPosicion, Quaternion.identity);
                hierba.transform.localScale = new Vector3(TamañoHierba, 1f, TamañoHierba);

                // Agregar la posición de la parcela a la lista de posiciones registradas
                posicionHierbas.Add(HierbaPosicion);
            }
        
        }
    }

}
