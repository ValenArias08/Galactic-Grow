using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Singleton pattern
    public static GameManager Instance { get; private set; }

    [Header("Player Stats")]
    // Player / Game Stats
    
    public int playerTotalScore;
    

    private PauseManager pauseManager;

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
        SceneManager.LoadScene(sceneName);
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
}
