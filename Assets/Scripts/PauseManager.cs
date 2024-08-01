using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    [Header("Game Canvas")]

    [SerializeField] private GameObject pauseCanvas, winCanvas, loseCanvas;
    //private GameObject pauseCanvasInstance;
    private InputAction pauseAction;
    private bool isPaused = false;

    private void Awake()
    {
        pauseAction = new InputAction(binding: "<Keyboard>/p");
        pauseAction.performed += ctx => TogglePause();
        pauseAction.Enable();
    }

    private void Start()
    {
        pauseCanvas.SetActive(false);
        winCanvas.SetActive(false);
        loseCanvas.SetActive(false);
    }

    private void OnDestroy()
    {
        pauseAction.Disable();
        pauseAction.performed -= ctx => TogglePause();
    }

    //Metodos

    public void TogglePause()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }
    // Pausar Juego
    public void PauseGame()
    {
        pauseCanvas.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    //Renaudar Juego
    public void ResumeGame()
    {
        if (pauseCanvas != null)
        {
            pauseCanvas.SetActive(false);
        }
        Time.timeScale = 1;
        isPaused = false;
    }

    // Ir al Menu principal
    public void MainMenu(string sceneName)
    {   
        HideLoseCanvas();
        HideWinCanvas();
        GameManager.Instance.ResetScore();

        Time.timeScale = 1;
        if (pauseCanvas != null)
        {
            pauseCanvas.SetActive(false);
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    // Reiniciar la Escena Actual
    public void RestartScene()
    {
        HideLoseCanvas();
        HideWinCanvas();
        UnityEngine.SceneManagement.SceneManager.LoadScene("DayScene");
        GameManager.Instance.ResetScore();

        Time.timeScale = 1;
        if (pauseCanvas != null)
        {
            pauseCanvas.SetActive(false);
        }
        //UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        

    }

    public void NextScene()
    {
        HideLoseCanvas();
        HideWinCanvas();
        UnityEngine.SceneManagement.SceneManager.LoadScene("DayScene");
        Debug.Log("Nueva oleada cargada");

        Time.timeScale = 1;
        if (pauseCanvas != null)
        {
            pauseCanvas.SetActive(false);
        }

    }

    //Canvas de Victoria

    public void ShowWinCanvas()
    {
        winCanvas.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void HideWinCanvas()
    {
        winCanvas.SetActive(false); 
    }

    //Canvas de GameOver
    public void ShowLoseCanvas()
    {
        loseCanvas.SetActive(true);
        Time.timeScale = 0;

        isPaused = true;
    }

    public void HideLoseCanvas()
    {
        loseCanvas.SetActive(false);
    }
}