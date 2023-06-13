using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class VegetableCounter : MonoBehaviour
{
    public GameObject carrotPrefab;
    public GameObject tomatoPrefab;
    public GameObject cornPrefab;

    private int carrotCount;
    private int tomatoCount;
    private int cornCount;

    private void Start()
    {
        ResetCounters();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("carrot"))
        {
            carrotCount--;
            Debug.Log("Carrot collided! Carrot count: " + carrotCount);
        }
        else if (other.CompareTag("tomato"))
        {
            tomatoCount--;
            Debug.Log("Tomato collided! Tomato count: " + tomatoCount);
        }
        else if (other.CompareTag("corn"))
        {
            cornCount--;
            Debug.Log("Corn collided! Corn count: " + cornCount);
        }

        // Verificar si todas las verduras han alcanzado el contador cero
        if (carrotCount <= 0 && tomatoCount <= 0 && cornCount <= 0)
        {
            ResetCounters();
        }
    }

    private void ResetCounters()
    {
        carrotCount = carrotPrefab != null ? Random.Range(1, 2) : 0;
        tomatoCount = tomatoPrefab != null ? Random.Range(1, 2) : 0;
        cornCount = cornPrefab != null ? Random.Range(1, 2) : 0;

        Debug.Log("Counters reset! Carrot count: " + carrotCount + ", Tomato count: " + tomatoCount + ", Corn count: " + cornCount);
    }
}


