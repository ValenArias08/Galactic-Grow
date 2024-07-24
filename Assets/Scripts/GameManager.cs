using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

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

    private void Start()
    {
        if (bgmSource != null && !bgmSource.isPlaying)
        {
            bgmSource.Play();  // Ensure background music is playing
        }
    }

    public float GetVolumeFX()
    {
        float value;
        mixer.GetFloat("VolFX", out value);
        return value;
    }

    public float GetVolumeMaster()
    {
        float value;
        mixer.GetFloat("VolMaster", out value);
        return value;
    }

    public bool IsMuted()
    {
        float value;
        mixer.GetFloat("VolMaster", out value);
        return value <= -80;
    }

    public void SetMute(bool isMuted)
    {
        if (IsMuted())
        {
            mixer.SetFloat("VolMaster", lastVolume);
        }
        else
        {
            mixer.GetFloat("VolMaster", out lastVolume);
            mixer.SetFloat("VolMaster", -80);
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
        //Método pausa
    }
    public void GameOver()
    {
        // game over logic
        // botón Volver a intentarlo -> reinicie el puntaje, las vidas y cargue la escena de día
        // botón Salir -> menú principal
    }


    
}
