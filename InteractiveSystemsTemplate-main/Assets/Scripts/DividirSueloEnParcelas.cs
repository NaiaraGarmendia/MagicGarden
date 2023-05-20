using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DividirSueloEnParcelas : MonoBehaviour
{
    public GameObject prefabParcela; // Prefab de la parcela
    public Vector3 inicioSuelo; // Punto inicial del suelo
    public Vector3 finSuelo; // Punto final del suelo
    public int tamanoParcela = 8; // Tamaño de la parcela

    void Start()
    {
        DividirSuelo();
    }

    void DividirSuelo()
    {
        // Calcular el número de parcelas en cada eje
        int cantidadParcelasX = Mathf.CeilToInt((finSuelo.x - inicioSuelo.x) / tamanoParcela);
        int cantidadParcelasZ = Mathf.CeilToInt((finSuelo.z - inicioSuelo.z) / tamanoParcela);

        // Generar las parcelas en las ubicaciones correspondientes
        for (int x = 0; x < cantidadParcelasX; x++)
        {
            for (int z = 0; z < cantidadParcelasZ; z++)
            {
                // Calcular la posición de la parcela
                Vector3 posicionParcela = new Vector3(
                    inicioSuelo.x + (x * tamanoParcela) + (tamanoParcela / 2f),
                    inicioSuelo.y,
                    inicioSuelo.z + (z * tamanoParcela) + (tamanoParcela / 2f)
                );

                // Instanciar la parcela en la posición calculada
                GameObject parcela = Instantiate(prefabParcela, posicionParcela, Quaternion.identity);
                parcela.transform.localScale = new Vector3(tamanoParcela, 1f, tamanoParcela);
            }
        }
    }
}

