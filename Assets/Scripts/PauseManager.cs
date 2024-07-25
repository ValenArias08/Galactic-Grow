using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseCanvasPrefab;
    private GameObject pauseCanvasInstance;
    private InputAction pauseAction;
    private bool isPaused = false;

    private void Awake()
    {
        if (FindObjectsOfType<PauseManager>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        pauseAction = new InputAction(binding: "<Keyboard>/p");
        pauseAction.performed += ctx => TogglePause();
        pauseAction.Enable();
    }

    private void OnDestroy()
    {
        pauseAction.Disable();
        pauseAction.performed -= ctx => TogglePause();
    }

    private void TogglePause()
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

    public void PauseGame()
    {
        if (pauseCanvasInstance == null)
        {
            pauseCanvasInstance = Instantiate(pauseCanvasPrefab);
            var panel = pauseCanvasInstance.transform.Find("Panel");
            if (panel != null)
            {
                panel.gameObject.SetActive(true);
            }
        }
        else
        {
            pauseCanvasInstance.gameObject.SetActive(true);
            var panel = pauseCanvasInstance.transform.Find("Panel");
            if (panel != null)
            {
                panel.gameObject.SetActive(true);
            }
        }
        Time.timeScale = 0;
        isPaused = true;
    }

    public void ResumeGame()
    {
        if (pauseCanvasInstance != null)
        {
            pauseCanvasInstance.SetActive(false);
        }
        Time.timeScale = 1;
        isPaused = false;
    }

    public void MainMenu(string sceneName)
    {
        Time.timeScale = 1;
        if (pauseCanvasInstance != null)
        {
            Destroy(pauseCanvasInstance);
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    public void RestartScene()
    {
        Time.timeScale = 1;
        if (pauseCanvasInstance != null)
        {
            Destroy(pauseCanvasInstance);
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}