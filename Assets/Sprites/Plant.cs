using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Plant : MonoBehaviour
{
    // Sprite original de Plant
    public Sprite plantSprite, plantSprite2, plantSprite3, plantSprite4, plantSprite5, plantSprite6, plantSprite7, plantSprite8;
    public Sprite currentSprite;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {   
        // Obtiene el componente SpriteRenderer adjunto al objeto Plant
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Si existe un estado de planta guardado en el GameManager, úsalo
        if (GameManager.Instance.plantState != null)
        {
            currentSprite = GameManager.Instance.plantState;
        }
        else
        {
            currentSprite = plantSprite; // Inicializar con el primer sprite si no hay estado guardado
        }

        // Asigna el sprite inicial
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = currentSprite;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto que entra en el trigger tiene el tag "Objeto"
        if (other.CompareTag("Objeto"))
        {
            // Cambia el sprite del objeto Plant a Plant2
            if (currentSprite == plantSprite)
            {
                ChangeSpriteToPlant(plantSprite2);
            }

            else if (currentSprite == plantSprite2)
            {
                ChangeSpriteToPlant(plantSprite3);
            }

            else if (currentSprite == plantSprite3)
            {
                ChangeSpriteToPlant(plantSprite4);
            }

            else if (currentSprite == plantSprite4)
            {
                ChangeSpriteToPlant(plantSprite5);
            }

            else if (currentSprite == plantSprite5)
            {
                ChangeSpriteToPlant(plantSprite6);
            }

            else if (currentSprite == plantSprite6)
            {
                ChangeSpriteToPlant(plantSprite7);
            }

            else if (currentSprite == plantSprite7)
            {
                ChangeSpriteToPlant(plantSprite8);
            }

            else
            {
                Debug.Log("Crecimiento completo");
            }
        }
    }

    private void ChangeSpriteToPlant(Sprite sprite)
    {
        if (spriteRenderer != null)
        {
            currentSprite = sprite;
            spriteRenderer.sprite = currentSprite;
            Debug.Log("Cambiando Sprite");
        }
    }
}
