using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cosechar : MonoBehaviour
{
   
    public GameObject verdura;
    public Vector3 tamañomaximo;
    private bool player1encima = false;
    private bool player2encima = false; 

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1"))
        {
            player1encima = true;
        }
        else if (other.CompareTag("Player3"))
        {
            player2encima = true;
        }

        CheckCollision();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player1"))
        {
            player1encima = false;
        }
        else if (other.CompareTag("Player3"))
        {
            player2encima = false;
        }

        CheckCollision();
    }

    private void CheckCollision()
    {
        Debug.Log(player1encima);
        Debug.Log(player2encima);
        Debug.Log(transform.localScale);
        if (player1encima && player2encima && transform.localScale == tamañomaximo)
        {
            // Ambos jugadores están en colisión y el prefab está en su tamaño máximo
            // Aquí puedes agregar la lógica para "recoger" el prefab
            Debug.Log("Prefab recogido por los jugadores");
        }
    }
}
