using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreWaveDisplay : MonoBehaviour
{

    public TextMeshProUGUI scoreTextObject;
    public int scoreValue;
    

    public TextMeshProUGUI waveTextObject;

    //start is called before the first frame update

    
    private void Start()
    {
        UpdateWaveValue();
    }

    //update is called once per frame
    private void Update()
    {
        scoreValue = GameManager.Instance.GetScore();
        UpdateScoreValue();



    }

    public void UpdateScoreValue()
    {
        scoreTextObject.text = "Score: " + scoreValue;
    }

    public void UpdateWaveValue()
    {
        
        //waveTextObject.text = "Night : " + GameManager.Instance.night;
    }
}
