using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [Header("Options")]
    public AudioMixer mixer;
    public AudioSource bgmSource;
    public AudioClip clicSound;
    private float lastVolume;

    // Player / Game Stats
    public int playerLifeCounter = 3;
    public int playerTotalScore = 0;

    //Pause menu
    public GameObject groupMenuPause;
    public bool isPaused = false;
    public InputActionReference pauseActionReference;

    private PauseManager pauseManager;

    // Singleton pattern
    public static GameManager Instance { get; private set; }

    public void AddScore(int score)
    {
        playerTotalScore += score;
        Debug.Log("Total Score: " + playerTotalScore);
    }
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

    private void OnEnable()
    {
        if (pauseManager == null)
        {
            pauseManager = FindObjectOfType<PauseManager>();
        }
    }

    private void Start()
    {
        if (bgmSource != null && !bgmSource.isPlaying)
        {
            bgmSource.Play();  // Ensure background music is playing
        }
    }

    private void Update()
    {
        if (pauseActionReference != null && pauseActionReference.action.triggered)
        {
            if (!isPaused)
            {
                PauseGame();
            }
            else
            {
                ResumeMenu();
            }
        }
    }

    private void PauseGame()
    {
        if (pauseManager == null)
        {
            pauseManager = FindObjectOfType<PauseManager>();
        }

        if (pauseManager != null)
        {
            pauseManager.PauseGame();
            isPaused = true;
        }
    }

    public void ResumeMenu()
    {
        if (pauseManager != null)
        {
            pauseManager.ResumeGame();
        }
        groupMenuPause.SetActive(false);////////////////
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void MainMenu(string sceneName)
    {
        if (pauseManager != null)
        {
            pauseManager.MainMenu(sceneName);
        }
    }

    public void RestartSceneMenu()
    {
        pauseManager.RestartScene();

    }

    public float GetVolumeFX()
    {
        float value;
        mixer.GetFloat("VolFX", out value);
        return value;
    }

    public float GetVolumeMaster()
    {
        mixer.GetFloat("VolMaster", out float value);
        return value;
    }

    public bool IsMuted()
    {
        mixer.GetFloat("VolMaster", out float value);
        return value <= -80;
    }

    public void SetMute(bool isMuted)
    {
        if (isMuted)
        {
            mixer.GetFloat("VolMaster", out lastVolume);
            mixer.SetFloat("VolMaster", -80);
        }
        else
        {
            mixer.SetFloat("VolMaster", lastVolume);
        }
    }

    public void ChangeVolumeMaster(float v)
    {
        mixer.SetFloat("VolMaster", v);
    }
    public void ChangeVolumeFX(float v)
    {
        mixer.SetFloat("VolFX", v);
    }

    public void PlaySoundButton()
    {
        bgmSource.PlayOneShot(clicSound);
    }

    //Adding score points
    private void AddScorePoints()
    {
        // score logic
    }

    // Scene management
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
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
        //M�todo pausa
    }
    public void GameOver()
    {
        // game over logic
        // bot�n Volver a intentarlo -> reinicie el puntaje, las vidas y cargue la escena de d�a
        // bot�n Salir -> men� principal
    }


    
}
