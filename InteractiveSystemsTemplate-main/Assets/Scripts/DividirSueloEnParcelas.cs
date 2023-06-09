using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DividirSueloEnParcelas : MonoBehaviour
{
    public GameObject prefabParcela; // Prefab de la parcela
    public int tamanoParcela; // Tamaño de la parcela
    

    private List<Vector3> posicionesParcelas; // Lista de posiciones de las parcelas creadas
    private Vector3 previousPosition;

   


    private void Start()
    {
        posicionesParcelas = new List<Vector3>();
        previousPosition = transform.position;
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.CompareTag("shovel"))
        {
            
          
            // Obtener la posición de la parcela en la que se encuentra el jugador
            Vector3 posicionParcela = new Vector3(
                Mathf.Floor(other.transform.position.x / tamanoParcela) * tamanoParcela + (tamanoParcela / 2f),
                0,
                Mathf.Floor(other.transform.position.z / tamanoParcela) * tamanoParcela + (tamanoParcela / 2f)
            );

            // Verificar si la posición de la parcela ya ha sido registrada
            if (!posicionesParcelas.Contains(posicionParcela))
            {
                // Instanciar la parcela en la posición calculada
                GameObject parcela = Instantiate(prefabParcela, posicionParcela, Quaternion.identity);
                parcela.transform.localScale = new Vector3(tamanoParcela, 1f, tamanoParcela);
                SoundManager.Instance.Playtierra();
                // Agregar la posición de la parcela a la lista de posiciones registradas
                posicionesParcelas.Add(posicionParcela);
            }
        
        }
    }

}
