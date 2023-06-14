using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class VegetableCounter : MonoBehaviour
{
    public GameObject carrotPrefab;
    public GameObject tomatoPrefab;
    public GameObject cornPrefab;

    public Text tomatoCounter;
    public Text cornCounter;
    public Text carrotCounter;

    private int carrotCount;
    private int tomatoCount;
    private int cornCount;

    private void Start()
    {
        ResetCounters();
        tomatoCounter.text = tomatoCount.ToString();
        carrotCounter.text = carrotCount.ToString();
        cornCounter.text = cornCount.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("carrot"))
        {
            carrotCount--;
            Debug.Log("Carrot collided! Carrot count: " + carrotCount);
            carrotCounter.text = carrotCount.ToString();
            SoundManager.Instance.PlayHarvest();

        }
        else if (other.CompareTag("tomato"))
        {
            tomatoCount--;
            Debug.Log("Tomato collided! Tomato count: " + tomatoCount);
            tomatoCounter.text =  tomatoCount.ToString();
            SoundManager.Instance.PlayHarvest();
        }
        else if (other.CompareTag("corn"))
        {
            cornCount--;
            Debug.Log("Corn collided! Corn count: " + cornCount);
            cornCounter.text = cornCount.ToString();
            SoundManager.Instance.PlayHarvest();
        }

        // Verificar si todas las verduras han alcanzado el contador cero
        if (carrotCount <= 0 && tomatoCount <= 0 && cornCount <= 0)
        {
            ResetCounters();
            cornCounter.text = cornCount.ToString();
            carrotCounter.text = carrotCount.ToString();
            tomatoCounter.text = tomatoCount.ToString();
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


