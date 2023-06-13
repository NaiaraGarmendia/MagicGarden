using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCosechar : MonoBehaviour
{
   
    public GameObject verdura;
    public Vector3 tamañomaximo;
    private bool player1encima = false;
    private bool player2encima = false;

    private GameObject player = null;
    private GameObject plant = null;

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Player"))
        {
            player1encima = true;
            player = other.gameObject;
           
        }
        else if (other.CompareTag("plant"))
        {
            player2encima = true;
            plant = other.gameObject;
        }

        if(player!= null && plant != null)
        {
            CheckCollision(player, plant);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player1encima = false;
           
        }
        else if (other.CompareTag("seeds"))
        {
            player2encima = false;
            
        }

        if (player != null && plant != null)
        {
            CheckCollision(player, plant);
        }
    }

    private void CheckCollision(GameObject player,GameObject plant)
    {
        Debug.Log(player1encima);
        Debug.Log(player2encima);
        Debug.Log(transform.localScale);
      
        if (plant.transform.localScale == tamañomaximo)
        {
            // Ambos jugadores están en colisión y el prefab está en su tamaño máximo
            // Aquí puedes agregar la lógica para "recoger" el prefab
            Debug.Log("Prefab recogido por los jugadores");
        }
    }
}
