using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regar_hierba : MonoBehaviour
{
    public List<GameObject> prefabHierba = new List<GameObject>(); // Prefab de la parcela
    public float TamañoHierba; // Tamaño de la parcela
    //public float EscalaHierba; // Tamaño de la parcela

    private List<Vector3> posicionHierbas; // Lista de posiciones de las parcelas creadas
    private Vector3 previousPosition;

   


    private void Start()
    {
        posicionHierbas = new List<Vector3>();
        previousPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        
        if (other.CompareTag("Water"))
        {
            
            growPlants(other);


        }
    }

    private void growPlants(Collider other)
    {
        int probGrow = Random.Range(0, 10);

        if (probGrow == 0)
        {

           

            // Obtener la posición de la parcela en la que se encuentra el jugador
            Vector3 HierbaPosicion = new Vector3(
                Mathf.Floor(other.transform.position.x / TamañoHierba) * TamañoHierba + (TamañoHierba / 2f),
                0,
                Mathf.Floor(other.transform.position.z / TamañoHierba) * TamañoHierba + (TamañoHierba / 2f)
            );
            // Verificar si la posición de la parcela ya ha sido registrada
            if (!posicionHierbas.Contains(HierbaPosicion))
            {
                int hierbaRandom = Random.Range(0, prefabHierba.Count);

                // Instanciar la parcela en la posición calculada
                GameObject hierba = Instantiate(prefabHierba[hierbaRandom], HierbaPosicion, prefabHierba[hierbaRandom].transform.rotation);
                //hierba.transform.localScale = new Vector3(EscalaHierba, 1f, EscalaHierba);

                // Agregar la posición de la parcela a la lista de posiciones registradas
                posicionHierbas.Add(HierbaPosicion);
            }
        }

    }

}
