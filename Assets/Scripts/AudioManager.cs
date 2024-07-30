using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("Audio")]
    public AudioMixer mixer;
    public AudioSource bgmSource;
    public AudioClip clicSound;

    private float lastVolume;

    private void Awake()
    {
        // Check if there is already an instance of AudioManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // Ensure only one instance exists
        }
    }

    private void Start()
    {
        if (bgmSource != null && !bgmSource.isPlaying)
        {
            bgmSource.Play();
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
}
