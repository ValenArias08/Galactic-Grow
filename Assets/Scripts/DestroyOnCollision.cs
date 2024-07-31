using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto que entra en el trigger tiene el tag "Objeto"
        if (other.CompareTag("Objeto"))
        {
            // Destruye el objeto que colisionó con el trigger
            Debug.Log("Destruyendo objeto: " + other.gameObject.name);
            Destroy(other.gameObject);
        }
    }
}
