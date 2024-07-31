using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public Sprite plantSprite; // Sprite original de Plant
    public Sprite plant2Sprite; // Nuevo sprite para Plant2

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        // Obtiene el componente SpriteRenderer adjunto al objeto Plant
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Asigna el sprite inicial
        if (spriteRenderer != null && plantSprite != null)
        {
            spriteRenderer.sprite = plantSprite;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto que entra en el trigger tiene el tag "Objeto"
        if (other.CompareTag("Objeto"))
        {
            // Cambia el sprite del objeto Plant a Plant2
            ChangeSpriteToPlant2();
        }
    }

    private void ChangeSpriteToPlant2()
    {
        if (spriteRenderer != null && plant2Sprite != null)
        {
            spriteRenderer.sprite = plant2Sprite;
            Debug.Log("Sprite cambiado a Plant2");
        }
    }
}
