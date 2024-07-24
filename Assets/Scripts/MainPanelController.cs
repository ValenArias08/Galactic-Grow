using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainPanelController : MonoBehaviour
{
    [Header("Options")]
    public Slider volumeFX;
    public Slider volumeMaster;
    public Toggle mute;
    public AudioMixer mixer;
    public AudioSource fxSource;
    public AudioClip clicSound;
    private float lastVolume;

    [Header("Panels")]
    public GameObject mainPanel;
    public GameObject optionsPanel;
    public GameObject creditsPanel;

  

    private void Awake()
    {
        volumeFX.onValueChanged.AddListener(ChangeVolumeFX);
        volumeMaster.onValueChanged.AddListener(ChangeVolumeMaster);
    }

    public void PlayDayScene(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void SetMute()
    {
        if (mute.isOn)
        {
            mixer.GetFloat("VolMaster", out lastVolume);
            mixer.SetFloat("VolMaster", -80);
        }
        else
        {
            mixer.SetFloat("VolMaster", lastVolume);
        }
    }

    public void OpenPanel(GameObject panel)
    {
        mainPanel.SetActive(false);
        optionsPanel.SetActive(false);
        creditsPanel.SetActive(false);
        panel.SetActive(true);
        PlaySoundButton();
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
        fxSource.PlayOneShot(clicSound);
    }
}
