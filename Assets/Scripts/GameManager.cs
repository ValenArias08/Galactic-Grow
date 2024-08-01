using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Singleton pattern
    public static GameManager Instance { get; private set; }

    [Header("Player Stats")]
    // Player / Game Stats
    
    public int playerTotalScore;

    private WaveManager waveManager;
    public int night;
    public int waveNumber;
    public int enemiesWave;
    public Sprite plantState;

    private PauseManager pauseManager;
    private Plant plantManager;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; 
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        pauseManager = GetComponent<PauseManager>();
        playerTotalScore = 0;
        night = 0;
        waveNumber = 0;
        enemiesWave = 5;
    }

    //Metodos

    // Manejo del estado y puntaje del player:

    public void AddScore(int score)
    {

        playerTotalScore += score;
        Debug.Log("Total Score: " + playerTotalScore);
    }

    // Player getting damaged / game over (only during Night phase)
    

    // Manejo de los estados del juego:

    public void TogglePause()
    {
        if (pauseManager != null)
        {
            pauseManager.TogglePause();
        }
    }

    // Manejo de escenas:

    public void LoadScene(string sceneName)
    {
        if (sceneName == "DayScene")
        {
            // Actualizar variables solo si no es la primera vez en DayScene
            if (night != 0)
            {
                night += 1;
                waveNumber += 1;
                enemiesWave += 3;
            }

            SceneManager.LoadScene(sceneName);
            Invoke("FindPlantManager", 0.1f);
        }
        else if(sceneName == "NightScene")
        {

            // Guardar el estado del sprite de la planta antes de ir a Noche
            if (plantManager != null)
            {
                SavePlantState(plantManager.currentSprite);
            }

            // Primera vez en NightScene
            if (night == 0)
            {
                night = 1;
                waveNumber = 1;
                enemiesWave = 5;
            }

            SceneManager.LoadScene(sceneName);
            Invoke("FindWaveManager", 0.1f); // Invocar después de que la escena se ha
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    //WaveManager encontrarlo
    private void FindWaveManager()
    {
        waveManager = FindObjectOfType<WaveManager>();
        if (waveManager != null)
        {
            waveManager.currentWave = waveNumber;
            waveManager.enemiesPerWave = enemiesWave;
            Debug.Log("WaveManager encontrado y actualizado.");
        }
        else
        {
            Debug.Log("WaveManager no encontrado en la escena actual.");
        }
    }

    //Encontrar Plant
    private void FindPlantManager()
    {
        plantManager = FindObjectOfType<Plant>();
        if (plantManager != null)
        {
            Debug.Log("PlantManager encontrado.");
        }
        else
        {
            Debug.Log("PlantManager no encontrado en la escena actual.");
        }
    }

    // Redirigir al menu principal
    public void MainMenu(string sceneName)
    {
        if (pauseManager != null)
        {
            pauseManager.MainMenu(sceneName);
        }
        if (sceneName == "MainScene")
        {
            // Handle additional Main Menu logic if needed
            if (Instance != null)
            {
                Destroy(Instance.gameObject);
            }
        }
    }

    public int GetScore()
    {
        return playerTotalScore;
    }

    // Reiniciar la escena
    public void RestartSceneMenu()
    {
        pauseManager.RestartScene();

    }

    public void GameOverRestart()
    {
        SceneManager.LoadScene("MainScene");
        Debug.Log("Game Over");
    }

    public void ResetScore()
    {
        playerTotalScore = 0;
        night = 0;
        waveNumber = 0;
        enemiesWave = 5;
    }

    public void SavePlantState(Sprite sprite)
    {
        plantState = sprite;
    }
}
