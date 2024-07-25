using UnityEngine;
using UnityEngine.UI;

public class MainPanelController : MonoBehaviour
{
    [Header("Panels")]
    public GameObject mainPanel;
    public GameObject optionsPanel;
    public GameObject controlsPanel;

    [Header("Options")]
    public Slider volumeFX;
    public Slider volumeMaster;
    public Toggle mute;

    private void Start()
    {
        // Inicializa los valores de los sliders y el toggle
        volumeFX.value = GameManager.Instance.GetVolumeFX();
        volumeMaster.value = GameManager.Instance.GetVolumeMaster();
        mute.isOn = GameManager.Instance.IsMuted();

        // Añadir listeners para los sliders y el toggle
        volumeFX.onValueChanged.AddListener(GameManager.Instance.ChangeVolumeFX);
        volumeMaster.onValueChanged.AddListener(GameManager.Instance.ChangeVolumeMaster);
        mute.onValueChanged.AddListener(delegate { GameManager.Instance.SetMute(mute.isOn); });
    }

    public void OpenPanel(GameObject panel)
    {
        mainPanel.SetActive(false);
        optionsPanel.SetActive(false);
        controlsPanel.SetActive(false);
        panel.SetActive(true);
        GameManager.Instance.PlaySoundButton();
    }

    
}
