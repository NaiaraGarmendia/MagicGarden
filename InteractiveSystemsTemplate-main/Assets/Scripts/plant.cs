using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plant : MonoBehaviour
{
    public GameObject florPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("seeds"))
        {
            // Verifica si el paquete no está siendo sostenido por el jugador
            
            GrabPackage grabPackage = collision.gameObject.GetComponentInParent<GrabPackage>();

            if (grabPackage != null && !grabPackage.pickedUp)
            {
                // Instancia la flor en la misma posición que la colisión
                Instantiate(florPrefab, collision.transform.position, Quaternion.identity);
            }
        
            
        }
    }   
}
