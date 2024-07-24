using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // Player / Game Stats

    public int playerLifeCounter = 3;
    public int playerTotalScore = 0;

    // Singleton pattern
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    //Adding score points

    private void AddScorePoints()
    {
        // score logic
    }

    // Scene management

    public void LoadScene(string sceneName)
    {
        // Load scene 
    }


    // Player getting damaged / game over (only during Night phase)
    public void LoseLife()
    {
        playerLifeCounter--;
        if (playerLifeCounter == 0)
        {
            GameOver();
        }
    }

    public void OnApplicationPause(bool pause)
    {
        //Método pausa
    }
    public void GameOver()
    {
        // game over logic
        // botón Volver a intentarlo -> reinicie el puntaje, las vidas y cargue la escena de día
        // botón Salir -> menú principal
    }

}
