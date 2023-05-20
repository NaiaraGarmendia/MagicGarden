using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorParcelas : MonoBehaviour
{
    public GameObject prefabParcela; // Prefab de la parcela
    public float distanciaGeneracion = 10f; // Distancia de generación de las parcelas

    private Transform player; // Referencia al Transform del jugador

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Asigna el Transform del jugador
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Parcela"))
        {
            // Genera una nueva parcela cuando el jugador atraviese el collider de una parcela
            GenerarParcela();
        }
    }

    private void GenerarParcela()
    {
        // Calcula la posición de generación de la nueva parcela
        Vector3 posicionGeneracion = player.position + (player.forward * distanciaGeneracion);

        // Instancia la nueva parcela en la posición calculada
        Instantiate(prefabParcela, posicionGeneracion, Quaternion.identity);
    }
}

