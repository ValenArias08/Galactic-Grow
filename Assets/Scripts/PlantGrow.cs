using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrow : MonoBehaviour
{
    private bool playerInRange = false;
    public float growthRate = 1.1f; // Rate at which the plant grows
    public KeyCode growKey = KeyCode.E; // Key to grow the plant
    //private WaterBehavior playerHasWater;


    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(growKey))
        {
            Debug.Log("Growth key pressed, growing the plant");
            Grow();
        }
    }

    public void Grow()
    {
        // Increase the scale of the plant to make it grow
        transform.localScale *= growthRate;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Player entered the trigger area");
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("Player exited the trigger area");
        }
    }
}

